import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestLogin } from '../models/RequestLogin';
import { ResponseLogin } from '../models/ResponseLogin';
import { HttpClient, HttpHeaders, HttpEventType, HttpRequest, HttpClientModule } from '@angular/common/http';
import {tap} from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient, private authService: AuthService) {}

  //com o pipe tap o login é encaspulado e fica aqui a resposabilidade atraves do service
  public doLogin(requestLogin: RequestLogin): Observable<ResponseLogin> {
    let headers = new HttpHeaders(); headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    
    return this.httpClient.post<ResponseLogin>(
      'https://localhost:44312/auth/authenticate',
      requestLogin, { headers }
    ).pipe(tap(loginResponse => this.executeLogin(requestLogin.login, loginResponse['jwt'])));/**///comentar para usar sem o esquema de rotas
  }

  public executeLogin(email: String, jwt: String): void {
    this.authService.saveLoginResponseJwt(jwt);
    let headers = new HttpHeaders({
      'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
    });
    console.log("Teste");
    this.authService.saveUserType('Student');
    // this.httpClient.get(`https://localhost:44312/auth/getType/${email}`)
    // .subscribe(response => this.authService.saveUserType(response['userType']));
  }
}
