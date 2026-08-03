import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductList } from './components/product-list/product-list';
import { ErrorPage } from './components/error-page/error-page';
import { ProductForm } from './components/product-form/product-form';

const routes: Routes = [
  { path: 'product-list', component: ProductList },
  { path: '', redirectTo: '/product-list', pathMatch: 'full' },
  { path: 'product-form', component: ProductForm }, 
  { path: 'product-form/:id', component: ProductForm } ,
  { path: 'error', component: ErrorPage },
  { path: '**', component: ErrorPage }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
