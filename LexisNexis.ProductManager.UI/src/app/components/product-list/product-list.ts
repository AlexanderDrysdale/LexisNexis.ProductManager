// product-list.component.ts
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, combineLatest, switchMap, finalize } from 'rxjs';
import { Client, GetProductsResult, ProductDTO } from '../../services/api-client';
import { LoadingOverlay } from '../loading-overlay/loading-overlay'
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.html',
  standalone: false,
})
export class ProductList implements OnInit {
  public pageNumber$ = new BehaviorSubject<number | undefined>(1);
  public pageSize$ = new BehaviorSubject<number | undefined>(10);
  public name$ = new BehaviorSubject<string | undefined>(undefined);
  public categoryId$ = new BehaviorSubject<number | undefined>(undefined);
  public loading = false;
  public totalCount = 0;

  products$ = combineLatest([
    this.pageNumber$,
    this.pageSize$,
    this.name$,
    this.categoryId$
  ]).pipe(
    switchMap(([pageNumber, pageSize, name, categoryId]) => {
      this.loading = true;
      return this.client.productGET(pageNumber, pageSize, name, categoryId)
        .pipe(finalize(() => this.loading = false));
    })
  );

  constructor(private client: Client, private router: Router) { }

  ngOnInit(): void {
    this.products$.subscribe((result: GetProductsResult) => {
      this.totalCount = result.totalCount ?? 0;
    });
  }

  onPageChange(event: any): void {
    this.pageNumber$.next(event.pageIndex + 1);
    this.pageSize$.next(event.pageSize);
  }

  onFilterChange(name?: string, categoryId?: number): void {
    this.name$.next(name);
    this.categoryId$.next(categoryId);
    this.pageNumber$.next(1);
  }

  // product-list.component.ts
  onEdit(product: ProductDTO): void {
    console.log('Editing product:', product);
    this.router.navigate(['/product-form', product.id]);
  }

  onDelete(product: ProductDTO): void {
    if (confirm(`Are you sure you want to delete "${product.name}"?`)) {
      this.client.productDELETE(product.id!).subscribe(() => {
        this.pageNumber$.next(this.pageNumber$.value);
      });
    }
  }

  onAddNew(): void {
    this.router.navigate(['/product-form']);
  }

}
