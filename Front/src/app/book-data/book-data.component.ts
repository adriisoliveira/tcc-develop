import { Component, OnInit } from '@angular/core';
import { Book, BookService } from '../resources/services/book.service';

@Component({
  selector: 'app-book-data',
  templateUrl: './book-data.component.html',
  styleUrls: ['./book-data.component.scss']
})
export class BookDataComponent implements OnInit {

  books: Book[];

  //to use a Dynamic table inpute any coluns, coluns do html
  cols: any[];

  totalRecords: number;

  //to use for a costum filter like used Author to express
  allAuthors: any[];

  constructor(private bookService: BookService) { }

  ngOnInit() {
    // this.bookService.get('').
    // toPromise().
    // then(data => this.books = data);
  

  /*Create a backing object named cols. It will be an array of name-value pairs for the columnn header names. */
  //to inicialize the filter from colun by field
  // this.cols = [
  //   { field: 'name', header: 'Name' },
  //   {field: 'author', header: 'Author' },
  //   { field: 'price', header: 'Price' }      
  // ];

  //no momento error no console browser
  //core.js:6241 ERROR TypeError: Cannot read properties of undefined (reading 'length')
  this.totalRecords=this.books.length;

  // //used tu imput a costum filtler inside a colun for HTML
  // this.allAuthors = [
  //   { label: 'All Authors', value: null },
  //   { label: 'Mario Puzo', value: 'Mario Puzo' },
  //   { label: 'J.R.R. Tolkien', value: 'J.R.R. Tolkien' },
  //   { label: 'J.K. Rowling', value: 'J.K. Rowling' },
  //   { label: 'author1', value: 'author1' },
  //   { label: 'author2', value: 'author2' },
  //   { label: 'author3', value: 'author3' },   
  // ];

  }
  
}
