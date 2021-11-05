import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestLogin } from '../models/RequestLogin';
import { ResponseLogin } from '../models/ResponseLogin';
import {tap} from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient, private authService: AuthService) {}

  //com o pipe tap o login é encaspulado e fica aqui a resposabilidade atraves do service
<<<<<<< HEAD
  /* public doLogin(requestLogin: RequestLogin): Observable<ResponseLogin> {
  let headers = new HttpHeaders(); headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    return this.httpClient.post<ResponseLogin>(
      'http://localhost:5000/auth/authenticate',/*"https://localhost:8080/teste/api/login",
      requestLogin
    ).pipe(tap(loginResponse => this.authService.loginResponse = loginResponse)); comentar para usar sem o esquema de rotas 
  } */
  public doLogin(requestLogin: RequestLogin): Observable<ResponseLogin> {
    let headers = new HttpHeaders(); headers = headers.set("Access-Control-Allow-Origin" , "*");

    return this.httpClient.post<ResponseLogin>(
      'https://localhost:44312/auth/authenticate',
      requestLogin, { headers }
    ).pipe(tap(loginResponse => this.authService.loginResponse = loginResponse));/**///comentar para usar sem o esquema de rotas
  }
}
=======
  public doLogin(requestLogin: RequestLogin): Observable<ResponseLogin> {
    let headers = new HttpHeaders(); headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.httpClient.post<ResponseLogin>(
      'https://localhost:44312/auth/authenticate',
      requestLogin, { headers }
    ).pipe(tap(loginResponse => this.authService.saveLoginResponseJwt(loginResponse['jwt'])));/**///comentar para usar sem o esquema de rotas
  }
}
>>>>>>> feature/develop/TCC-31-Front-Controller-PythonAPI
