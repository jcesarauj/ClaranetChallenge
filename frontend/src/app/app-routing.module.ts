import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubscribeNewsletterComponent } from './pages/subscribe-newsletter/subscribe-newsletter.component';

const routes: Routes = [
  { path: "", component: SubscribeNewsletterComponent },
  { path: "subscribe", component: SubscribeNewsletterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
