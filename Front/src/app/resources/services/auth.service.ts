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
    return Boolean(this.loginResponse?.jwt)
  }
}
