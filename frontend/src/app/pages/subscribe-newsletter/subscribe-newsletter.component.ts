import { Component, OnInit } from '@angular/core';
import { NewsLetter } from './NewsLetter';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NewsLetterService } from './news-letter.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-subscribe-newsletter',
  templateUrl: './subscribe-newsletter.component.html',
  styleUrls: ['./subscribe-newsletter.component.scss']
})
export class SubscribeNewsletterComponent implements OnInit {

  newLetter: NewsLetter;
  newLetterForm!: FormGroup;
  newsLetterService : NewsLetterService

  constructor(newsLetterService : NewsLetterService, private toast: ToastrService, private spinner: NgxSpinnerService) {
    this.newLetter = new NewsLetter();
    this.newsLetterService = newsLetterService;
  }

  ngOnInit(): void {
    this.newLetterForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
      howTheyHeardAboutUs: new FormControl('', [Validators.required]),
      reasonForSigningUp: new FormControl(''),
    });
  }

  submit() {
    if (this.newLetterForm.invalid) return;

    this.spinner.show();
    const toast = this.toast;

    this.newsLetterService.save(this.newLetter).then((data: any) => {
      toast.success("Newsletter added with success");
      this.spinner.hide();
    })
    .catch(error => {
      const defaultMessage = "Error to add a newsletter, contact the support";
      
      if(error.response?.data?.errors?.length > 0){
        error.response?.data?.errors.forEach(function (message : string) {
          toast.error(message);
        }); 
        
        this.spinner.hide();
        return;
      }      

      toast.error(defaultMessage);       
      this.spinner.hide();
    });
  }

  get email() {
    return this.newLetterForm.get('email')!
  }

  get howTheyHeardAboutUs() {
    return this.newLetterForm.get('howTheyHeardAboutUs')!
  }
}
