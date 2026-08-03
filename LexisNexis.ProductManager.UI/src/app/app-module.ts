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
// import { CategoryManagement } from './components/category-management/category-management';
// import { MatTreeModule } from '@angular/material/tree';
// import { MatIconModule } from '@angular/material/icon';
// import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    App,
    ProductList,
    ProductForm,
    ErrorPage,
    SearchBox,
    LoadingOverlay,
    Navbar,
    // CategoryManagement,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatProgressSpinnerModule,
    FormsModule,
    // MatTreeModule,
    // MatIconModule,
    // MatButtonModule
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
