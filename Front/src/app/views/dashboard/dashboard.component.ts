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
  
  (function(d, m){
    var kommunicateSettings = 
        {"appId":"dFH1acvKl0NRhqvHmtnOYRxOipIY5lkP","popupWidget":true,"automaticChatOpenOnNavigation":true};
    var s = document.createElement("script"); s.type = "text/javascript"; s.async = true;
    s.src = "https://widget.kommunicate.io/v2/kommunicate.app";
    var h = document.getElementsByTagName("head")[0]; h.appendChild(s);
    (window as any).kommunicate = m; m._globals = kommunicateSettings;
})(document, (window as any).kommunicate || {});
}

  
    /*Metodo para modificar a a tela de Dashbord para Resumo */
    // public doResumo(): void{
    //   this.router.navigate(['resumo-texto'])
    // }
  
    // /*Metodo para modificar a a tela de Dashbord para Page Rank */
    // public doRank(): void{
    //   this.router.navigate(['page-rank'])
    // }
  }
  