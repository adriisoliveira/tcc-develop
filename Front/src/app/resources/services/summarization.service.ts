import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class SummarizationService {

  constructor(private http: HttpClient) {}

  summy(text, lineQuantity): Observable<String> {
    let headers = new HttpHeaders({
      'Content-Type' : 'application/json; charset=utf-8',
      'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
    });
    var requestData = {
      Text: text,
      LineQuantity: lineQuantity
    };
    
    return this.http.post('https://localhost:44312/summarization/summy', requestData, {headers, responseType: 'text'})
    .pipe();
  }
}