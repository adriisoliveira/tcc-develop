import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestLogin } from '../models/RequestLogin';
import { ResponseLogin } from '../models/ResponseLogin';
import { tap } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})

export class LoginService {
  constructor(private httpClient: HttpClient, private authService: AuthService) {}

  public doLogin(requestLogin: RequestLogin): Observable<ResponseLogin> {
    let headers = new HttpHeaders(); headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.httpClient.post<ResponseLogin>(
      'https://localhost:44312/auth/authenticate',
      requestLogin, { headers }
    ).pipe(tap(loginResponse => this.authService.saveLoginResponseJwt(loginResponse['jwt'])));/**///comentar para usar sem o esquema de rotas
  }
}
