import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
    return this.http.get<any>('/src/assets/books.json')
      .toPromise()
      .then(res => <Book[]>res.json().data.any)
      .then(data => { return data; });
    }
}