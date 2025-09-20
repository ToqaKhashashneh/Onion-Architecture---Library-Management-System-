import { Routes } from '@angular/router';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { BookListComponent } from './books/book-list/book-list.component';

export const routes: Routes = [
    {path:'categories', component:CategoryListComponent},
    {path:'', redirectTo:'books', pathMatch:'full'},
    {path:'books', component:BookListComponent},
];
