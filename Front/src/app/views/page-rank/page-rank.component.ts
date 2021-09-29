import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-rank',
  templateUrl: './page-rank.component.html',
  styleUrls: ['./page-rank.component.scss']
})
export class PageRankComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  public doBackToMenu(): void{
    this.router.navigate(['dashboard'])
  }

}
