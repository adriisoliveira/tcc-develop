//serviço para guardar as infos do login antes de fazer guarda rotas
import { Injectable } from '@angular/core';
import { ResponseLogin } from '../models/ResponseLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  //constructor() { } //não precisa do construtor nesse caso
  //propriedade que tem o JWT o TOKEN da API se tiver nulo ou undefined retorna false
  public loginResponse: ResponseLogin;

  //metodo para limpar o reponse
  public clear(): void{
    this.loginResponse = undefined;
  }

  //metodo pra ver se esta autenticado ou n
  //se existir retorna true e se n ou undefined false
  public isAuthenticated(): boolean{
    //return Boolean(this.loginResponse && this.loginResponse.jwt); ou usando o ? Optional Chaining
    //só le o JWT se a variavel LoginResponse estiver disponivel
    return Boolean(this.loginResponse?.jwt ?? localStorage.getItem('loginResponseJwt'))
  }

  public saveLoginResponseJwt(jwt): void{
    localStorage.setItem('loginResponseJwt', jwt);
    this.loginResponse = new ResponseLogin();
    this.loginResponse.jwt = jwt;
    ///TODO: trocar LocalStorage por Cookie
  }

  public saveUserType(userType): void {
    localStorage.setItem('userType', userType);
  }

  public getUserType() : any {
    return localStorage.getItem('userType');
  }
}
