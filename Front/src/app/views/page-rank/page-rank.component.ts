import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';


import { Book, BookService } from '../../resources/services/book.service';

@Component({
  selector: 'app-page-rank',
  templateUrl: './page-rank.component.html',
  styleUrls: ['./page-rank.component.scss']
})
export class PageRankComponent implements OnInit {

  books: Book[];

  constructor(
    private router: Router,
    private bookService: BookService
  ) { }

  ngOnInit()  {
    this.bookService.getBooks().
      then(books => this.books = books);
  }

  public doBackToMenu(): void{
    this.router.navigate(['dashboard'])
  }

}
