import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


//to use for get a menuBar for PrimeNG
import { MenuItem } from 'primeng/api';
import { Book, BookService } from 'src/app/resources/services/book.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
  })
  export class DashboardComponent implements OnInit {
  
    items: MenuItem[];
    books: Book[];
  
    constructor (private router: Router, private bookService: BookService) { }
  
    //norvamente :void
    ngOnInit(){
      this.bookService.getBooks().then(books => this.books = books);
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
  