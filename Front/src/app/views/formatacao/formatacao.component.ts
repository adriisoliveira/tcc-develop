import { STRING_TYPE } from '@angular/compiler';
import { Component, OnInit, ElementRef, ViewChild, Optional } from '@angular/core';
import { Router } from '@angular/router';
import html2canvas from 'html2canvas';
import { textAlign } from 'html2canvas/dist/types/css/property-descriptors/text-align';
import {jsPDF} from 'jspdf';
import {MenuItem} from 'primeng/api';
import { Options } from 'selenium-webdriver';

@Component({
  selector: 'app-formatacao',
  templateUrl: './formatacao.component.html',
  styleUrls: ['./formatacao.component.scss']
})
export class FormatacaoComponent implements OnInit {

  //@ViewChild('content', {static: false}) content: ElementRef;
  @ViewChild('document', {static:false}) el: ElementRef;
  items: MenuItem[]; 
  ckeditorContent;
  public value1: string;
  text1: string;
  element: any;

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

  // printPDF(){
  //   let pdf = new jsPDF('p', 'pt', 'a4');
  //   pdf.html(this.el.nativeElement,{
  //     callback:(pdf) => {
  //       pdf.save("Document.pdf");
  //       console.log;
  //     }

  //   })
  // }

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

  download() {

    // var doc = new jsPDF();
    // doc.text('20', 20, 20);
    // doc.text('This is client-side Javascript, pumping out a PDF.', 30, 20);
    // doc.addPage();
    // doc.text('Another page.', 30, 20);

    // // Save the PDF
    // doc.save('Test.pdf');
    
}

GeneratePDF () {
  // html2canvas(this.element.nativeElement, <Html2Canvas.Html2CanvasOptions>{
  //   onrendered: function(canvas: HTMLCanvasElement) {
  //     var pdf = new jsPDF('p','pt','a4');    
  //     var img = canvas.toDataURL("image/png");
  //     pdf.addImage(img, 'PNG', 10, 10, 580, 300);
  //     pdf.save('web.pdf');
  //   }
  // });
}

public downloadPDF() {
  //  const doc = new jsPDF();

  //  const specialElementHandlers = {
  //     '#editor': function (element, renderer) {
  //      return true;
  //      }
  //  };

  //  const content = this.content.nativeElement;

  //  doc.fromHTML(content.innerHTML, 15, 15, {
  //     width: 190,
  //    'elementHandlers': specialElementHandlers
  //  });


  //  doc.save('fileName.pdf');
  
}

getPDF() {
  var doc = new jsPDF();
 
  // // We'll make our own renderer to skip this editor
  // var specialElementHandlers = {
  //   '#getPDF': function(element, renderer){
  //     return true;
  //   },
  //   '.controls': function(element, renderer){
  //     return true;
  //   }
  // };

  // // All units are in the set measurement for the document
  // // This can be changed to "pt" (points), "mm" (Default), "cm", "in"
  // doc.fromHTML($('.pdf').get(0), 15, 15, {
  //   'width': 170, 
  //   'elementHandlers': specialElementHandlers
  // });

  doc.save('Generated.pdf');
}

printCapa(): void{
  var pdf = new jsPDF('p', 'pt', 'a4');
  var source = document.getElementById("capaDocument");
  
  pdf.html(source);

  // setTimeout é necessário, sem ele a função não tem tempo o bastante de escrever o conteudo do pdf
  setTimeout(function() {
    pdf.save('Capa.pdf');
  }, 2000);
}

printFolhaRosto(): void{
  var pdf = new jsPDF('p', 'pt', 'a4');
  var source = document.getElementById("folhaRosto");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Folha de Rosto.pdf');
  }, 2000);
}

printFichaAprovacao(): void{
  var pdf = new jsPDF('p', 'pt', 'a4');
  var source = document.getElementById("fichaAprovacao");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Ficha de Aprovação.pdf');
  }, 2000);
}

printDedicatoria(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("dedicatoria");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Dedicatoria.pdf');
  }, 2000);
}

printResumo(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("resumo");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Resumo.pdf');
  }, 2000);
}

printAbstract(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("abstract");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Abstract.pdf');
  }, 2000);
}

printListas(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("listas");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Listas.pdf');
  }, 2000);
}

printSumario(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("sumario");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Sumario.pdf');
  }, 2000);
}

printIntroducao(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("introducao");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Introdução.pdf');
  }, 2000);
}

printDesenvolvimento(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("desenvolvimento");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Desenvolvimento.pdf');
  }, 2000);
}

printConclusao(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("conclusao");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Conclusao.pdf');
  }, 2000);
}

printReferencias(): void{
  let pdf = new jsPDF('p', 'pt', 'a4');
  
  var source = document.getElementById("referencias");
  
  pdf.html(source);

  setTimeout(function() {
    pdf.save('Referencias.pdf');
  }, 2000);
}

// printCapa(): void{
//   let pdf = new jsPDF('p', 'pt', 'a4');
  
//   var source = document.getElementById("documentPrint");
  
//   pdf.html(source);

//   setTimeout(function() {
//     pdf.save('Document.docx');
//   }, 2000);
// }
}