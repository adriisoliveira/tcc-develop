import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
//parte do 31 front
import { SummarizationService } from 'src/app/resources/services/summarization.service';


@Component({
  selector: 'app-resumo-texto',
  templateUrl: './resumo-texto.component.html',
  styleUrls: ['./resumo-texto.component.scss']
})
//parte do 31 front
export class ResumoTextoComponent implements OnInit {  
  toSummarizeText: String;
  summarizedText: String;
  lineQuantity: number;
  constructor(
    private router: Router,
    private summarizationService: SummarizationService
  ) {
    this.toSummarizeText = "";
    this.summarizedText = "";
    this.lineQuantity = 1;
  }
  ngOnInit(): void {
  }

  public doBackToMenu(): void{
    this.router.navigate(['dashboard'])
  }
//parte do 31 front
  public setSummarizedText():void{
    console.log('funcional');
    this.summarizationService.summy(this.toSummarizeText, this.lineQuantity).subscribe(data => {this.summarizedText = data});
  }
}