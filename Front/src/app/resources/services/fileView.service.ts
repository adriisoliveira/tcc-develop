import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpEventType, HttpRequest, HttpClientModule} from '@angular/common/http';
import { DataView } from '../models/DataView';

@Injectable ({
    providedIn: 'root'
})

export class FileViewService {
    constructor(private http: HttpClient) {}

    render(){
        return this.http.get<any>(`https://localhost:44312/file/getAll/computacao?maxResults=25`)
        .toPromise()
        .then(res => <DataView[]>res.data)
        .then(data => { return data; });
      }
}