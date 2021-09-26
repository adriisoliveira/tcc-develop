import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(
    private router: Router
    ) { }

  ngOnInit(): void {
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
