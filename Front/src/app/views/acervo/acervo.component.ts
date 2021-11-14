import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import {MenuItem} from 'primeng/api';
import { HttpHeaders } from '@angular/common/http/http';

@Component({
  selector: 'app-acervo',
  templateUrl: './acervo.component.html',
  styleUrls: ['./acervo.component.scss']
})
export class AcervoComponent implements OnInit {

  items: MenuItem[]; 
  searchItem: String;

  constructor(
    private router: Router,
  ) {
    this.searchItem = "";
  }

  ngOnInit(): void {
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
  }

  // public search():void{
  //   this.alertService.info('Aguarde...', 'Pesquisando');
  //   this.bookService.get(this.searchText).
  //   toPromise().
  //   then(data => this.books = data).
  //   catch(data => this.alertService.error('Erro'));
  //   setTimeout(()=>{
  //     this.alertService.close()
  //   }, 3000);

  // }

  // public downloadSearchFile(id){
  //   let headers = new HttpHeaders({
  //     'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
  //   });

  //   this.http.get(https://localhost:44312/file/download/${id}, { responseType: 'arraybuffer', headers: headers })
  //   .subscribe(response => this.download(response, "application/pdf"));

  // }

  // public download(data: any, fileType: string) {
  //     let blob = new Blob([data], { type: fileType });
  //     let result = window.open(window.URL.createObjectURL(blob));
  //     if (!result  result.closed  typeof result.closed == 'undefined')
  //         alert( 'Desative o bloqueador de Pop-up e tente novamente.');
  // }

}