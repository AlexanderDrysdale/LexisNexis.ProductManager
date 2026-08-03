import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductDTO, CategoryDTO, Client } from '../../services/api-client';
import { Observable, forkJoin } from 'rxjs';

@Component({
  selector: 'app-product-form',
  standalone: false,
  templateUrl: './product-form.html',
  styleUrls: ['./product-form.css'],
})
export class ProductForm {
  public product: ProductDTO = new ProductDTO({
    id: undefined,
    name: '',
    description: '',
    sku: '',
    price: 0,
    quantity: 0,
    categoryId: undefined
  });

  public categories: CategoryDTO[] = [];
  public loading = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private client: Client
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    const product$ = id
      ? this.client.productGET2(id)
      : new Observable<ProductDTO>(observer => {
        observer.next(new ProductDTO({
          id: undefined,
          name: '',
          description: '',
          sku: '',
          price: 0,
          quantity: 0,
          categoryId: undefined
        }));
        observer.complete();
      });

    const categories$ = this.client.categoryAll();

    forkJoin([product$, categories$]).subscribe(([p, cats]) => {
      this.product = ProductDTO.fromJS(p);
      this.categories = cats;
      this.loading = false;
    });
  }

  onSave(): void {
    if (this.product.id) {
      this.client.productPUT(this.product.id, this.product).subscribe(() => {
        this.router.navigate(['/product-list']);
      });
    } else {
      this.client.productPOST(this.product).subscribe(() => {
        this.router.navigate(['/product-list']);
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/product-list']);
  }
}
