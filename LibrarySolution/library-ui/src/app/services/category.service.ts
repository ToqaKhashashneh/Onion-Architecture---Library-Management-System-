import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Category {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private api = 'https://localhost:7260/api/Category';

  constructor(private _http: HttpClient) {}

  getAllCategories(): Observable<Category[]> {
    return this._http.get<Category[]>(`${this.api}/GetAllCategories`);
  }

  getCategoryById(id: number): Observable<Category> {
    return this._http.get<Category>(`${this.api}/GetCategoryById/${id}`);
  }

  addCategory(newCategory: Omit<Category, 'id'>): Observable<number> {
    return this._http.post<number>(`${this.api}/AddCategory`, newCategory);
  }

  updateCategory(id: number, updatedCategory: Category): Observable<void> {
    return this._http.put<void>(`${this.api}/UpdateCategory/${id}`, updatedCategory);
  }

  deleteCategory(id: number): Observable<void> {
    return this._http.delete<void>(`${this.api}/DeleteCategory/${id}`);
  }
}
