import { Component } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
export interface CategoryNode {
  id: number;
  name: string;
  children?: CategoryNode[];
}

@Component({
  selector: 'app-category-management',
  standalone: false,
  templateUrl: './category-management.html',
  styleUrl: './category-management.css',
})
export class CategoryManagement {
  private data: CategoryNode[] = [
    {
      id: 1, name: 'Electronics', children: [
        { id: 2, name: 'Phones' },
        { id: 3, name: 'Laptops' }
      ]
    },
    { id: 4, name: 'Books' }
  ];

  dataChange = new BehaviorSubject<CategoryNode[]>([]);
  dataSource = this.dataChange.asObservable();

  addNode(parent: CategoryNode, name: string) {
    const newNode: CategoryNode = { id: Date.now(), name };
    parent.children = parent.children || [];
    parent.children.push(newNode);
    this.dataChange.next(this.data);
  }

  editNode(node: CategoryNode, newName: string) {
    node.name = newName;
    this.dataChange.next(this.data);
  }

  deleteNode(parent: CategoryNode, node: CategoryNode) {
    parent.children = parent.children?.filter(c => c !== node);
    this.dataChange.next(this.data);
  }

}
