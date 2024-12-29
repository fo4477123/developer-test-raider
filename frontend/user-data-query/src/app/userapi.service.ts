import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserapiService {

  private apiUrl = ' http://localhost:5256/api/Users';
  constructor(private http: HttpClient) {
  } 
   
  getUsers(): Observable<any[]> { 
    return this.http.get<any[]>(this.apiUrl); 
  }
}