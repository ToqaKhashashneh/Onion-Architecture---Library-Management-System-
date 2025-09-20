import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookService } from '../../services/book.service';
import { CategoryService, Category } from '../../services/category.service';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterOutlet, RouterLink],
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: any[] = [];
  categories: Category[] = [];
  total = 0;

  // For modal
  isModalOpen = false;
  isDeleteModalOpen = false;
  modalTitle = 'Add Book';
  currentBook: any = null;

  // form inputs
  title: string = '';
  author: string = '';
  publishedOn: string = '';
  selectedCategoryIds: number[] = [];

  constructor(
    private bookService: BookService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.loadBooks();
    this.loadCategories();
  }

  loadBooks(): void {
    this.bookService.getAllBooksWithCategories().subscribe(data => {
      this.books = data;
      this.total = data.length;
    });
  }

  loadCategories(): void {
    this.categoryService.getAllCategories().subscribe(data => {
      this.categories = data;
    });
  }

  // Open add modal
  openAddModal() {
    this.modalTitle = 'Add Book';
    this.currentBook = null;
    this.title = '';
    this.author = '';
    this.publishedOn = '';
    this.selectedCategoryIds = [];
    this.isModalOpen = true;
  }

  // Open edit modal
  openEditModal(b: any) {
    this.modalTitle = 'Edit Book';
    this.currentBook = b;
    this.title = b.title;
    this.author = b.author;
    this.publishedOn = b.publishedOn.split('T')[0];
    this.selectedCategoryIds = []; 
    this.isModalOpen = true;
  }

  // Save (Add or Update)
  saveBook() {
    if (!this.title.trim() || !this.author.trim()) return;

    if (this.currentBook) {
      this.bookService.updateBook(this.currentBook.bookId, {
        id: this.currentBook.bookId,
        title: this.title,
        author: this.author,
        publishedOn: this.publishedOn,
        categoryIds: this.selectedCategoryIds
      }).subscribe(() => this.loadBooks());
    } else {
      this.bookService.addBook({
        title: this.title,
        author: this.author,
        publishedOn: this.publishedOn,
        categoryIds: this.selectedCategoryIds
      }).subscribe(() => this.loadBooks());
    }

    this.closeModal();
  }

  // Delete
  openDeleteModal(b: any) {
    this.currentBook = b;
    this.isDeleteModalOpen = true;
  }

  confirmDelete() {
    if (!this.currentBook) return;
    this.bookService.deleteBook(this.currentBook.bookId).subscribe(() =>
       this.loadBooks());
    this.closeDeleteModal();
  }

  // Close modals
  closeModal() {
    this.isModalOpen = false;
  }

  closeDeleteModal() {
    this.isDeleteModalOpen = false;
  }
}
