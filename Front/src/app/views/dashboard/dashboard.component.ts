import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import {HttpClient, HttpHeaders, HttpEventType, HttpRequest, HttpClientModule} from '@angular/common/http';
import { DataView } from 'src/app/resources/models/DataView';
import { DataViewService } from 'src/app/resources/services/dataView.service';
import {MenuItem} from 'primeng/api';
import { FileView } from 'src/app/resources/models/FileView';
import { FileViewService } from 'src/app/resources/services/fileView.service';


@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
  })
  export class DashboardComponent implements OnInit {
    [x: string]: any;
  
    items: MenuItem[]; 
    dataViewComponent: DataView[];
    fileViewComponent: FileView[];
    cols: any[];

    constructor(
      private http: HttpClient,
      private router: Router,
      private dataViewService: DataViewService,
      private fileViewService: FileViewService
      ) { }
  

    ngOnInit(){
      this.fileViewService.render().then(fileView =>this.fileViewComponent = fileView);
      //this.dataViewService.getDataView().then(dataView =>this.dataViewComponent = dataView);

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
        label:'Acervo',
        icon:'pi pi-file-pdf',
        id: 'btnAcervo',
        url: '/#/acervo',
      },
       {
        label:'Enviar Arquivo',
        icon:'pi pi-cloud-upload',
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

  this.cols = [
    { field: 'title', header: 'Titulo' },
    { field: 'subtitle', header: 'Subititulo' },
    { field: 'author', header: 'Autor' },
  ];
  
  (function(d, m){
    var kommunicateSettings = 
        {"appId":"dFH1acvKl0NRhqvHmtnOYRxOipIY5lkP","popupWidget":true,"automaticChatOpenOnNavigation":true};
    var s = document.createElement("script"); s.type = "text/javascript"; s.async = true;
    s.src = "https://widget.kommunicate.io/v2/kommunicate.app";
    var h = document.getElementsByTagName("head")[0]; h.appendChild(s);
    (window as any).kommunicate = m; m._globals = kommunicateSettings;
})(document, (window as any).kommunicate || {});
}

    
    // render(){
    //   const httpOptions = {
    //       headers: new HttpHeaders({
    //         'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
    //       })
    //     }

    // return this.http.get<FileList[]>(`https://localhost:44312/file/getAll/?maxResults=25`, httpOptions);
    // }
  
    /*Metodo para modificar a a tela de Dashbord para Resumo */
    // public doResumo(): void{
    //   this.router.navigate(['resumo-texto'])
    // }
  
    // /*Metodo para modificar a a tela de Dashbord para Page Rank */
    // public doRank(): void{
    //   this.router.navigate(['page-rank'])
    // }




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
            alert( 'Desative o bloqueador de Pop-up e tente novamente.');
    }
    
  }
  