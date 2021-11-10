import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { List } from '../models/List';

@Injectable ({
    providedIn: 'root'
})

export class ListService {
    constructor(private http: HttpClient) {}

    getList() {
        return this.http.get<any>('../assets/list.json')
            .toPromise()
            .then(res => <List[]>res.data)
            .then(data => { return data; });
    }
}