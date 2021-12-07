import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { MenuItem } from 'primeng/api';
import { FileView } from 'src/app/resources/models/FileView';
import { FileViewService } from 'src/app/resources/services/fileView.service';
import { AuthService } from 'src/app/resources/services/auth.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
  })

export class DashboardComponent implements OnInit {
  [x: string]: any;
  public fileview = [];
  searchItem: String;
  fileViewComponent: FileView[];
  cols: any[];
  files: FileList[];
  inputSearch: any;

  constructor(
    private http: HttpClient,
    private authServ: AuthService,
    private fileViewService: FileViewService,
  ) { }
  

  ngOnInit(){
    this.inputSearch = document.getElementById('inputSearch');

    this.fileViewService.render().subscribe(data => this.fileViewComponent = data);

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

  public isStudent(): boolean{
    return this.authServ.getUserType() == 'Student';
  }
}