import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SummarizationService } from 'src/app/resources/services/summarization.service';


@Component({
  selector: 'app-resumo-texto',
  templateUrl: './resumo-texto.component.html',
  styleUrls: ['./resumo-texto.component.scss']
})
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

  public setSummarizedText():void{
    console.log('funcional');
    this.summarizationService.summy(this.toSummarizeText, this.lineQuantity).subscribe(data => {this.summarizedText = data});
  }
}