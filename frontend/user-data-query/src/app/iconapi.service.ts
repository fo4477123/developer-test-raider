import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class IconapiService {
  private iconUrl = 'http://localhost:5256/api/icons'; // 獲取圖標的 API URL

  constructor(private http: HttpClient) { }

  getImagePath(iconName:string):string{
    return `${this.iconUrl}/${iconName}`;
  }

  getImage(iconName: string): Observable<Blob> {
    console.log(`Fetching icon: ${this.iconUrl}/${iconName}`);
    return this.http.get(`${this.iconUrl}/${iconName}`, 
    { 
      responseType: 'blob', observe: 'response',headers: { 'transfer-cache-include-headers': 'Content-Type' } }).pipe( 
        map(response => {
          if (response.body) 
            { 
              console.log(response.headers.get("Content-Type"));
              return new Blob([response.body], { type: 'image/png' }); 
            } 
            else { 
              throw new Error('Response body is null'); 
            }
           })
      );
    }  
}

