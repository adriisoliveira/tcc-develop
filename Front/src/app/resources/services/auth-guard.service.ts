//serviço para configurar o acesso direto na barra de pesquisa
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})

//esta implementando a inteface do angular respossavel pela ação
export class AuthGuardService implements CanActivate{

  constructor(private authService : AuthService) { 

  }
  //n precisa da rota e do estado nesse caso (route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
  // o retorno é bolean então o restante pode apagar | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>
  canActivate(): boolean  {
    return this.authService.isAuthenticated();
  }
}
