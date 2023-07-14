import { Injectable } from '@angular/core';
import axios from 'axios';
import { environment as env } from '../../../environments/environment';
import { NewsLetter } from './NewsLetter';

@Injectable({
  providedIn: 'root'
})
export class NewsLetterService {

  constructor() { }

  save(newLetter: NewsLetter) {
    return axios.post(`${env.newLetterUri}/v1/newsletter`, {
      Email: newLetter.email,
      HeardAboutUs: parseInt(newLetter.heardAboutUs),
      ReasonForSigningUp: newLetter.reasonForSigningUp
    });
  }
}