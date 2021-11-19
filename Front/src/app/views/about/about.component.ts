import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})

export class AboutComponent implements OnInit {
  items: MenuItem[]; 

  constructor(
      private router: Router
      ) { }

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
}