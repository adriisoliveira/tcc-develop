import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FileView } from '../models/FileView';
import { Observable } from 'rxjs';

@Injectable ({
    providedIn: 'root'
})

export class FileViewService {

  constructor(private http: HttpClient) {}

  render( ):Observable<FileView[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
      })
    }
    return this.http.get<any>(`https://localhost:44312/file/getAll/estigmas?maxResults=25`, httpOptions);
  }   
}