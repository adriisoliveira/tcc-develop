import { Component, OnInit } from '@angular/core';
import { BookService } from '../resources/services/book.service';
import { Book } from '../resources/models/Book';

@Component({
  selector: 'app-book-data',
  templateUrl: './book-data.component.html',
  styleUrls: ['./book-data.component.scss']
})
export class BookDataComponent implements OnInit {
  books: Book[];
  cols: any[];
  totalRecords: number;

  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.totalRecords=this.books.length;
  }
}