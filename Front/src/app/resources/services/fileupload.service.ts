//comentado na tcc-69

// import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
// @Injectable({
//   providedIn: 'root',
// })
// export class FileUploadService {
  
//   constructor(private httpClient: HttpClient) {}
// //   Observable<ResponseLogin>
//   public upload(file : File): String {
//       return 'c:/asdasdasdsa'
//     // let headers = new HttpHeaders(); headers = headers.set('Content-Type', 'application/json; charset=utf-8');

//     // return this.httpClient.post<ResponseLogin>(
//     //   'https://localhost:44312/auth/authenticate',
//     //   requestLogin, { headers }
//     // ).pipe(tap(loginResponse => this.authService.saveLoginResponseJwt(loginResponse['jwt'])));/**///comentar para usar sem o esquema de rotas
//   }
//   // public postFile(fileToUpload: File): boolean {
//   //   const formData: FormData = new FormData();
//   //   formData.append(fileToUpload.name, fileToUpload);

//   //   let headers = new HttpHeaders({
//   //     'Content-Type' : 'multipart/form-data',
//   //     'Authorization' : 'bearer '+ localStorage.getItem('loginResponseJwt')
//   //     //'Authorization' : 'bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJleHAiOjE2MzYwNTA2ODEsImlzcyI6ImFwaWNvbnRyb2xsZXIiLCJhdWQiOiJhcGljb250cm9sbGVyIn0.MLGyM5VBx6gN1C27wNGmWhRTUEWu0JwnFWbAulhaFo4'
//   //   });

//   //   const uploadReq = new HttpRequest('POST', 'https://localhost:44312/file/save', formData); 

//   //   this.httpClient.request(uploadReq).subscribe(e => {e.type ==  return true;});
//   //   return true;
//   //     // return this.httpClient.post<boolean>('https://localhost:44312/file/save', formData, { headers }).pipe();/**///comentar para usar sem o esquema de rotas

//   //     // return this.httpClient
//   //     //   .post(endpoint, formData, { headers: headers })
//   //     //   .pipe()
//   //     //   .map(() => { return true; })
//   //     //   .catch((e) => this.handleError(e));
//   // }

// }
