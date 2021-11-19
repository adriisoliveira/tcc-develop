import { Component, OnInit, ElementRef, ViewChild, Optional } from '@angular/core';
import { Router } from '@angular/router';
import { HTMLOptions, jsPDF } from 'jspdf';
import { MenuItem } from 'primeng/api';
import * as html2pdf from 'html2pdf.js';

@Component({
  selector: 'app-formatacao',
  templateUrl: './formatacao.component.html',
  styleUrls: ['./formatacao.component.scss']
})

export class FormatacaoComponent implements OnInit {
  @ViewChild('document', {static:false}) el: ElementRef;
  items: MenuItem[];
  public value1: string;
  text1: string;
  element: any;

  constructor(
      private router: Router
    ) { }

  ngOnInit(){
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

  infos():any{
    value:'';
  }

  instituicao: string;
  aluno1: string;
  aluno2: string;
  aluno3: string;
  aluno4: string;
  aluno5: string;
  aluno6: string;
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
    this.aluno1;
    this.aluno2;
    this.aluno3;
    this.aluno4;
    this.aluno5;
    this.aluno6;
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

  getPDF() {
    var doc = new jsPDF();

    doc.save('Generated.pdf');
  }

  printCapa(): void {
    const element: Element = document.getElementById("capaDocument");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Capa.pdf'
    }

    html2pdf().from(element).set(opt).save();
  }

  printFolhaRosto(): void{
    const element: Element = document.getElementById("folhaRosto");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'FolhaRosto.pdf'
    }

    html2pdf().from(element).set(opt).save();
  }

  printFichaAprovacao(): void{
    const element: Element = document.getElementById("fichaAprovacao");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'FichaAprovacao.pdf'
    }
  
    html2pdf().from(element).set(opt).save();
  }

  printDedicatoria(): void{
    const element: Element = document.getElementById("dedicatoria");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Dedicatoria.pdf'
    }
  
    html2pdf().from(element).set(opt).save();
  }

  printResumo(): void{
    const element: Element = document.getElementById("resumo");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Resumo.pdf'
    }
  
    html2pdf().from(element).set(opt).save();
  }

  printAbstract(): void{
    const element: Element = document.getElementById("abstract");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Abstract.pdf'
    }
  
    html2pdf().from(element).set(opt).save();
  }

  printListas(): void{
    const element: Element = document.getElementById("listas");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Listas.pdf'
    }
  
    html2pdf().from(element).set(opt).save();
  }

  printSumario(): void{
    const element: Element = document.getElementById("sumario");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Sumario.pdf'
    }
  
    html2pdf().from(element).set(opt).save();
  }

  printIntroducao(): void{
    const element: Element = document.getElementById("introducao");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Introducao.pdf'
    }

    html2pdf().from(element).set(opt).save();
  }

  printDesenvolvimento(): void{
    const element: Element = document.getElementById("desenvolvimento");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Desenvolvimento.pdf'
    }

    html2pdf().from(element).set(opt).save();
  }

  printConclusao(): void{
    const element: Element = document.getElementById("conclusao");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Conclusao.pdf'
    }

    html2pdf().from(element).set(opt).save();
  }

  printReferencias(): void{
    const element: Element = document.getElementById("referencias");
    const opt: HTMLOptions = {
      margin: 30,
      filename: 'Referencias.pdf'
    }

    html2pdf().from(element).set(opt).save();
  }
}