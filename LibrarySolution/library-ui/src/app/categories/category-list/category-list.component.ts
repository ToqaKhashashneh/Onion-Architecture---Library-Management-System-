
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryService, Category } from '../../services/category.service';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink, RouterOutlet],
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories: Category[] = [];
  total = 0;

  // For modal
  isModalOpen = false;
  isDeleteModalOpen = false;
  modalTitle = 'Add Category';
  currentCategory: Category | null = null;
  nameInput: string = '';

  constructor(private service: CategoryService) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.service.getAllCategories().subscribe(data => {

      this.categories = data;
      this.total = data.length;
    });
  }

  // Open add modal
  openAddModal() {
    this.modalTitle = 'Add Category';
    this.currentCategory = null;
    this.nameInput = '';
    this.isModalOpen = true;
  }

  // Open edit modal
  openEditModal(cat: Category) {
    this.modalTitle = 'Edit Category';
    this.currentCategory = cat;
    this.nameInput = cat.name;
    this.isModalOpen = true;
  }

  // Save (Add or Update)
  saveCategory() {
    if (!this.nameInput.trim()) return;

    if (this.currentCategory) {
      this.service.updateCategory(this.currentCategory.id, {
        id: this.currentCategory.id,
        name: this.nameInput
      }).subscribe(() => this.load());
    } else {
      this.service.addCategory({ name: this.nameInput }).subscribe(() => this.load());
    }

    this.closeModal();
  }

  // Delete
  openDeleteModal(cat: Category) {
    this.currentCategory = cat;
    this.isDeleteModalOpen = true;
  }

  confirmDelete() {
    if (!this.currentCategory) return;
    this.service.deleteCategory(this.currentCategory.id).subscribe(() => this.load());
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
