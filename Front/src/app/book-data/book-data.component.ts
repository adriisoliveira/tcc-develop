import { Component, OnInit } from '@angular/core';
import { Book, BookService } from '../resources/services/book.service';

@Component({
  selector: 'app-book-data',
  templateUrl: './book-data.component.html',
  styleUrls: ['./book-data.component.scss']
})
export class BookDataComponent implements OnInit {

  books: Book[];

  constructor(private bookService: BookService) { }

  ngOnInit() {
      this.bookService.getBooks().
      then(books => this.books = books);
  }

}
