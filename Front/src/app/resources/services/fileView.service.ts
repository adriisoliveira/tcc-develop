import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpEventType, HttpRequest, HttpClientModule} from '@angular/common/http';
import {FileView } from '../models/FileView';
import { Observable } from 'rxjs';

@Injectable ({
    providedIn: 'root'
})

export class FileViewService {
  files: FileView[];
  constructor(private http: HttpClient) {}

  render(inputSearch):Observable<FileView[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
      })
    }
    return this.http.get<any>(`https://localhost:44312/file/getAll/${inputSearch}?maxResults=25`, httpOptions);
  }
}