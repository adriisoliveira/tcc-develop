import { STRING_TYPE } from '@angular/compiler';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import jsPDF from 'jspdf';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-formatacao',
  templateUrl: './formatacao.component.html',
  styleUrls: ['./formatacao.component.scss']
})
export class FormatacaoComponent implements OnInit {

  @ViewChild('content',{ static:false}) el!:ElementRef;
  items: MenuItem[]; 

  public value1: string;
  text1: string;

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
  }

  printPDF(){
    let pdf = new jsPDF('p', 'pt', 'a4');
    pdf.html(this.el.nativeElement,{
      callback:(pdf) => {
        pdf.save("Document.pdf");
        console.log;
      }

    })
  }

  infos():any{
    value:'';
  }

  instituicao: string;
  alunos: string;
  titulo: string;
  subtitulo: string;
  cidade: string;
  ano: string;
  textoFolha: string;
  dedicatoria: string;
  epigrafe: string;
  resumo: string;
  abstract: string;
  listaIlustracao: string;
  listaTabelas: string;
  abreviaturas: string;
  sumario: string;
  introducao: string;
  desenvolvimento: string;
  conclusao: string;
  referencias: string;

  salvarDados(){
    this.instituicao;
    this.alunos;
    this.titulo;
    this.subtitulo;
    this.cidade;
    this.ano;
    this.textoFolha;
    this.dedicatoria;
    this.epigrafe;
    this.resumo;
    this.abstract;
    this.listaIlustracao;
    this.listaTabelas;
    this.abreviaturas;
    this.sumario;
    this.introducao;
    this.desenvolvimento;
    this.conclusao;
    this.referencias;
    alert("Informações prontas para download")
  }
}
