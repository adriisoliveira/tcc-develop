import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface Book {
  name;
  price;
  author;
}

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {}

  getBooks() {
    return this.http.get<any>('assets/books.json')
      .toPromise()
      .then(res => <Book[]>res.data)
      .then(data => { return data; });
    }
}