import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class ShrtUrlservice {

    constructor(private httpClient: HttpClient) { }

    createShrtUrl(originalUrl: string): Observable<string> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json'
        });
        return this.httpClient.post<string>('api/urlshortener', JSON.stringify(originalUrl), { headers})
        .pipe(map((response: string) => {
        return response;
         }));
    }

    getLink(shortUrl: string): Observable<string> {
        return this.httpClient.get('api/urlshortener/' + shortUrl).pipe(map((x: string) => {
            return x;
        }));
      }
}
