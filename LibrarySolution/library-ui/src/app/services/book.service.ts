import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Book {
  id: number;
  title: string;
  author: string;
  publishedOn: string;
  categoryIds: number[];
}

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private api = 'https://localhost:7260/api/Books';

  constructor(private _http: HttpClient) { }

  getAllBooks(): Observable<Book[]> {
    return this._http.get<Book[]>(`${this.api}/GetAllBooks`);
  }

  getBookById(id: number): Observable<Book> {
    return this._http.get<Book>(`${this.api}/GetBookById/${id}`);
  }

  addBook(newBook: Omit<Book, 'id'>): Observable<number> {
    return this._http.post<number>(`${this.api}/AddBook`, newBook);
  }

  updateBook(id: number, updatedBook: Book): Observable<void> {
    return this._http.put<void>(`${this.api}/UpdateBook/${id}`, updatedBook);
  }

  deleteBook(id: number): Observable<void> {
    return this._http.delete<void>(`${this.api}/DeleteBook/${id}`);
  }

  getAllBooksWithCategories(): Observable<any[]> {
    return this._http.get<any[]>(`${this.api}/GetAllBooks-with-categories`);
  }
}
