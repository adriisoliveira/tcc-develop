import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


//to use for get a menuBar for PrimeNG
import { MenuItem } from 'primeng/api';
import { BookService } from 'src/app/resources/services/book.service';
//import { ListService } from 'src/app/resources/services/list.service';
import { Book } from 'src/app/resources/models/Book';
//import { List } from 'src/app/resources/models/List';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  items: MenuItem[];
  bookLocal: Book[];      // Objeto usado para puxar info no html
  
  constructor (private router: Router, private bookService: BookService/*, public listService: ListService*/) { }
  
  //norvamente :void
  ngOnInit(){
    //this.listService.getList().then(list => this.listLocal = list);
    this.bookService.getBooks().then(book => this.bookLocal = book);

    //menu bar itens
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
        label:'Recomendador',
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
  
  /*Metodo para modificar a a tela de Dashbord para Resumo */
  // public doResumo(): void{
  //   this.router.navigate(['resumo-texto'])
  // }
  
  // /*Metodo para modificar a a tela de Dashbord para Page Rank */
  // public doRank(): void{
  //   this.router.navigate(['page-rank'])
  // }
} 