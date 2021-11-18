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

    render( ):Observable<FileView[]> {

        // const httpOptions = {
        //     headers: new HttpHeaders({
        //       'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
        //     })
        //   }

        // return this.http.get<any>(`https://localhost:44312/file/getAll/ecologia?maxResults=25`,httpOptions)
        // .toPromise()
        // .then(res => <FileView[]>res.json())
        // .then(data => { return data; });
        
      
        // return this.http.get<FileView[]>(`https://localhost:44312/file/getAll/ecologia?maxResults=25`, httpOptions);


        const httpOptions = {
            headers: new HttpHeaders({
              'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
            })
          }
          return this.http.get<any>(`https://localhost:44312/file/getAll/estigmas?maxResults=25`, httpOptions);
          // this.http.get<IFileView[]>(`https://localhost:44312/file/getAll/estigmas?maxResults=25`, httpOptions).subscribe();

        }
      
    }
