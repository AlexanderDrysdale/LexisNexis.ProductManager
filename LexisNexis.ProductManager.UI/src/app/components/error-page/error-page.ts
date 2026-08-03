import { Component } from '@angular/core';

@Component({
  selector: 'app-error-page',
  standalone: false,
  templateUrl: './error-page.html',
  styleUrl: './error-page.css',
})
export class ErrorPage {
  message = 'Oops! Something went wrong.';
  details = 'The page you are looking for could not be found or an unexpected error occurred.';
}
