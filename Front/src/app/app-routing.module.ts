import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookDataComponent } from './book-data/book-data.component';
import { AuthGuardService } from './resources/services/auth-guard.service';
import { LoginComponent } from './views/login/login.component';

/**Declarar o obj dos modulos */
const routes: Routes = [
  { path: '', component: LoginComponent },//rota raiz sem guard rote onde todos tem acesso


  { path: 'books', component: BookDataComponent },

  {
    path: 'dashboard',//só acessar se estiver logado, autorizado o mesmo nos outros
    //chama passa aray e diz qual guarda do componets
    canActivate: [AuthGuardService],//com isso configura a guarde rota
    loadChildren: () =>
      import('./views/dashboard/dashboard.module').then(
        (m) => m.DashboardModule
      ),
  },

  {
    path: 'dashboardAluno',
    canActivate: [AuthGuardService],//com isso configura a guarde rota
    loadChildren: () =>
      import('./views/dashboardAluno/dashboardAluno.module').then(
        (m) => m.DashboardAlunoModule
      ),
  },

  /**m = Modulo then recebe modulo M e retorna uma restu .... module*/
  {path:'resumo-texto', 
  loadChildren: () =>
    import('./views/resumo-texto/resumo-texto.module').then(
      (m) => m.ResumoTextoModule
    ),
  },

  {path:'page-rank', 
  loadChildren: () =>
    import('./views/page-rank/page-rank-routing.module').then(
      (m) => m.PageRankRoutingModule
    ),
  },

  {path:'acervo', 
  loadChildren: () =>
    import('./views/acervo/acervo-routing.module').then(
      (m) => m.AcervoRoutingModule
    ),
  },

  {path:'formatacao', 
  loadChildren: () =>
    import('./views/formatacao/formatacao.module').then(
      (m) => m.FormatacaoModule
    ),
  },
  
  {path:'file-upload', 
  loadChildren: () =>
    import('./views/file-upload/file-upload-routing.module').then(
      (m) => m.FileUploadRoutingModule
    ),
  },

  {path:'about', 
  loadChildren: () =>
    import('./views/about/about.module').then(
      (m) => m.AboutModule
    ),
  },

  
  //redirecionamento caso n ache uma rota
  {path:'**', redirectTo: ''},
];

//comentar o useHash ou setar dalse para usar diretamente pela url sem logar
@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  //imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
