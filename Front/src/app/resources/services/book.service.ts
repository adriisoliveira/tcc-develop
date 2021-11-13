import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
export class Book {
  id: String;
  title: String;
  url: String;
  pageRankPonctuation: number;
  
  constructor(id: String, title: String, url: String, pageRankPonctuation: number) {
    this.id = id;
    this.title = title;
    this.url = url;
    this.pageRankPonctuation = pageRankPonctuation;
  }
}

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {}

  get(search): Observable<Book[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
      })
    }

    return this.http.get<Book[]>('https://localhost:44312/webpages/get/' + search, httpOptions);
  }

  post(render): Observable<Book[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
      })
    }

    return this.http.post<Book[]>('https://localhost:44394/crawler/enqueue?url=' + render, httpOptions);
  }
}