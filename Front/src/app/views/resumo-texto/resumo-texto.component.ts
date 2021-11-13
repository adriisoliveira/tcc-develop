import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SummarizationService } from 'src/app/resources/services/summarization.service';

import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-resumo-texto',
  templateUrl: './resumo-texto.component.html',
  styleUrls: ['./resumo-texto.component.scss']
})
export class ResumoTextoComponent implements OnInit {  

  items: MenuItem[]; 

  toSummarizeText: String;
  summarizedText: String;
  lineQuantity: number;
  constructor(
    private router: Router,
    private summarizationService: SummarizationService
  )
  {
    this.toSummarizeText = "";
    this.summarizedText = "";
    this.lineQuantity = 1;
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

  // public doBackToMenu(): void{
  //   this.router.navigate(['dashboard'])
  // }

  public setSummarizedText():void{
    console.log('funcional');
    this.summarizationService.summy(this.toSummarizeText, this.lineQuantity).subscribe(data => {this.summarizedText = data});
  }
}