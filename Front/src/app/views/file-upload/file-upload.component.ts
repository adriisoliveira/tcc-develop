import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import {MenuItem} from 'primeng/api';
import {AlertService} from '../../resources/services/alert.service';
// import { FileUploadService } from '../../resources/services/fileupload.service';
// import {FileUpload} from 'primeng/fileupload';
import {HttpClient, HttpHeaders, HttpEventType, HttpRequest, HttpClientModule} from '@angular/common/http';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})

export class FileUploadComponent implements OnInit {
  fileToUpload:File;
  fileName: String;
  items: MenuItem[];
  alertService: AlertService;
  author: String;

  constructor(
    private router: Router,
    //private fileUploadService: FileUploadService,
    private http: HttpClient
  ) {
    this.fileName = "";
    //this.fileUploadService = new FileUploadService(http);
    this.alertService = new AlertService();
    this.author = "";
  }

  onFileSelected(event) {
    this.fileName = event.target.files[0].name;
  }

  upload(files) {  
    if (files.length === 0){
      return;
    }
    
      const formData = new FormData();  
    
      for (let file of files)
        formData.append(file.name, file);  
    
        formData.append("author", this.author.toString());

        let headers = new HttpHeaders({
          'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
        });
        
        const uploadReq = new HttpRequest('POST', 'https://localhost:44312/file/save', formData, {
          headers: headers,
          reportProgress: true,
        });
      
        this.http.request(uploadReq).subscribe(event => {
          if (event.type === HttpEventType.Response)
          {
            if(event.status == 200){
              this.alertService.info('Sucesso', 'Arquivo enviado com sucesso');
              this.fileName = "";
              this.author = "";
            }else{
              this.alertService.error('Erro', 'O arquivo não pôde ser enviado');
            }
          }
        });
      }

  ngOnInit()  {
    this.items = [
      {
        label:'Home',
        icon:'pi pi-fw pi-home',
        id: 'btnDashboard',
        url: '/#/dashboard',
      },
      {
        label:'Sumarizador',
        icon:'pi pi-fw pi-book',
        id: 'btnResumo',
        url: '/#/resumo-texto',
      },
    
      {
        label:'Recomendador',
        icon:'pi pi-fw pi-search-plus',
        id: 'btnSugestionador',
        url: '/#/page-rank',
      },
      {
        label:'Formatador',
        icon:'pi pi-fw pi-pencil',
        id: 'btnSugestionador',
        url: '/#/formatacao',
      },        
      {
        label:'Enviar Arquivo',
        icon:'pi pi-fw pi-search-plus',
        id: 'btnEnviarArquivo',
        url: '/#/file-upload',
      },
      {
        label:'Sobre Nós',
        icon:'pi pi-fw pi-info-circle',
        id: 'btnSugestionador',
        url: '/#/about',
      },
      {
        label:'Sair',
        icon:'pi pi-fw pi-power-off',
        url: '/#/login',
        id: 'btnQuit',
      },
    ];
  }
}
