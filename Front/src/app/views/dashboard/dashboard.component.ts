import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { DataViewService } from 'src/app/resources/services/dataView.service';
import { MenuItem } from 'primeng/api';
import { FileView } from 'src/app/resources/models/FileView';
import { FileViewService } from 'src/app/resources/services/fileView.service';
import { MenuInitizaliation } from 'src/app/resources/services/menu.service';
// import { DataView } from 'src/app/resources/models/DataView';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
  })

export class DashboardComponent implements OnInit {
  [x: string]: any;
  public fileview = [];
  searchItem: String;
  items: MenuItem[]; 
  fileViewComponent: FileView[];
  cols: any[];
  files: FileList[];
  menu: MenuInitizaliation;
  inputSearch: any;
  // dataViewLocal: DataView[];

  constructor(
    private http: HttpClient,
    private router: Router,
    private fileViewService: FileViewService,
    private dataViewService: DataViewService
  ) { }
  

  ngOnInit(){
    this.inputSearch = document.getElementById('inputSearch');
    // this.dataViewService.getDataView().then(data => this.dataViewLocal = data);

    this.fileViewService.render(this.inputSearch).subscribe(data => this.fileViewComponent = data);

    this.menu.menuInit(this.items);

    this.cols = [
      { field: 'title', header: 'Titulo' },
      { field: 'subtitle', header: 'Subititulo' },
      { field: 'author', header: 'Autor' },
      { field: 'action', header: 'Ação' },
    ];
  }

  public downloadSearchFile(id){
    let headers = new HttpHeaders({
      'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
    });

    this.http.get(`https://localhost:44312/file/download/${id}`, { responseType: 'arraybuffer', headers: headers })
    .subscribe(response => this.download(response, "application/pdf"));

  }

  public download(data: any, fileType: string) {
    let blob = new Blob([data], { type: fileType });
    let result = window.open(window.URL.createObjectURL(blob));
    if (!result || result.closed || typeof result.closed == 'undefined')
      alert('Desative o bloqueador de Pop-up e tente novamente.');
  }
}