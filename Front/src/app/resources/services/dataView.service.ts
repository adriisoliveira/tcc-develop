import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataView } from '../models/DataView';

@Injectable ({
    providedIn: 'root'
})

export class DataViewService {
    constructor(private http: HttpClient) {}

    getDataView() {
        return this.http.get<any>('../assets/dataView.json')
            .toPromise()
            .then(res => <DataView[]>res.data)
            .then(data => { return data; });
    }
}