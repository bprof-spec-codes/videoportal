import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {RegisterDto} from "../dto/Register.dto";
import { Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(
    private http: HttpClient
  ) {}

  register(model: RegisterDto): Observable<unknown> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      observe: "response" as 'body'
    };

    return this.http.post(
      'https://localhost:3001',
      model,
      httpOptions);

  }
}
