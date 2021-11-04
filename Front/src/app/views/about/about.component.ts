import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

//to use for get a menuBar for PrimeNG
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
      label:'Resumo',
      icon:'pi pi-fw pi-book',
      id: 'btnResumo',
      url: '/#/resumo-texto',
    },
      {
          label:'Sugestionador',
          icon:'pi pi-fw pi-search-plus',
          id: 'btnSugestionador',
          url: '/#/page-rank',
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
