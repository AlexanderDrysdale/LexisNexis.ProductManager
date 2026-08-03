import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { provideHttpClient } from '@angular/common/http';
import { ProductList } from './components/product-list/product-list';
import { ProductForm } from './components/product-form/product-form';
import { ErrorPage } from './components/error-page/error-page';
import { SearchBox } from './components/search-box/search-box';
import { API_BASE_URL, Client } from './services/api-client';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoadingOverlay } from './components/loading-overlay/loading-overlay';
import { Navbar } from './components/navbar/navbar';
import { FormsModule } from '@angular/forms'; 

@NgModule({
  declarations: [
    App,
    ProductList,
    ProductForm,
    ErrorPage,
    SearchBox,
    LoadingOverlay,
    Navbar,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatProgressSpinnerModule,
    FormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient(),
    Client,
    { provide: API_BASE_URL, useValue: 'https://localhost:5001' },
  ],
  bootstrap: [App],
})
export class AppModule {}
