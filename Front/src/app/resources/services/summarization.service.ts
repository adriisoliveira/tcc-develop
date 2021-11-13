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
        //'Authorization' : 'bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJleHAiOjE2MzYwNTA2ODEsImlzcyI6ImFwaWNvbnRyb2xsZXIiLCJhdWQiOiJhcGljb250cm9sbGVyIn0.MLGyM5VBx6gN1C27wNGmWhRTUEWu0JwnFWbAulhaFo4'
      });
      //n é erro de auth mesmo trocando ele entende e n vai
      var requestData = {
        Text: text,
        LineQuantity: lineQuantity
      };
        return this.http.post('https://localhost:44312/summarization/summy', requestData, {headers, responseType: 'text'})
        .pipe();
    }
}