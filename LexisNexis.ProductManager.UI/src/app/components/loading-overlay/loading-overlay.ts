import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-loading-overlay',
  standalone: false,
  templateUrl: './loading-overlay.html',
  styleUrl: './loading-overlay.css',
})
export class LoadingOverlay {
  @Input() loading = false;
}
