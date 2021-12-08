import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestLogin } from '../../resources/models/RequestLogin';
import { AuthService } from 'src/app/resources/services/auth.service';
import { AlertService } from '../../resources/services/alert.service';
import { LoginService } from '../../resources/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public requestLogin: RequestLogin;

  constructor(
    private loginService: LoginService,
    private authServ: AuthService,
    private alertService: AlertService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.requestLogin = new RequestLogin();
  }

  /* Faz chamada pro DOLogin recebe o token da API na variavel data, nesse modelo n esta guardando o valor*/
  public doLogin(): void {
    this.loginService.doLogin(this.requestLogin).subscribe(
      (data) => {
        if (this.authServ.getUserType() == 'Student')
          this.router.navigate(['dashboardAluno']);
        else
          this.router.navigate(['dashboard']);
      },
      (httpError) => {
        this.alertService.error(httpError.error.message);
      }
    );
  }
}
