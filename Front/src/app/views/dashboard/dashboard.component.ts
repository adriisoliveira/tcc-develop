import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


//to use for get a menuBar for PrimeNG
import {MenuItem} from 'primeng/api';


@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
  })
  export class DashboardComponent implements OnInit {
  
    items: MenuItem[]; 
  
    constructor(
      private router: Router
      ) { }
  
    //norvamente :void
    ngOnInit(){
      //menu bar itens
      this.items = [
          
        /* {
          label:'Arquivos',
          icon:'pi pi-fw pi-file',
          items:[
              {
                  label:'New',
                  icon:'pi pi-fw pi-plus',
                  items:[
                  {
                      label:'Bookmark',
                      icon:'pi pi-fw pi-bookmark'
                  },
                  {
                      label:'Video',
                      icon:'pi pi-fw pi-video'
                  },
  
                  ]
              },
              {
                  label:'Delete',
                  icon:'pi pi-fw pi-trash'
              },
              {
                  separator:true
              },
              {
                  label:'Export',
                  icon:'pi pi-fw pi-external-link'
              }
          ]
      },
      
      {
          label:'Usuarios',
          icon:'pi pi-fw pi-user',
          items:[
              {
                  label:'Novo',
                  icon:'pi pi-fw pi-user-plus',
                  
              },
              {
                  label:'Deletar',
                  icon:'pi pi-fw pi-user-minus',
  
              },
              {
                  label:'Busca',
                  icon:'pi pi-fw pi-users',
                  items:[
                  {
                      label:'Filter',
                      icon:'pi pi-fw pi-filter',
                      items:[
                          {
                              label:'Print',
                              icon:'pi pi-fw pi-print'
                          }
                      ]
                  },
                  {
                      icon:'pi pi-fw pi-bars',
                      label:'List'
                  }
                  ]
              }
          ]
      }, */
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
          url: '/#/books',
      },
      {
          label:'Sair',
          icon:'pi pi-fw pi-power-off',
          url: '/#/login',
          id: 'btnQuit',
      },
      
  ];
  }
  
    /*Metodo para modificar a a tela de Dashbord para Resumo */
    public doResumo(): void{
      this.router.navigate(['resumo-texto'])
    }
  
    /*Metodo para modificar a a tela de Dashbord para Page Rank */
    public doRank(): void{
      this.router.navigate(['page-rank'])
    }
  }
  