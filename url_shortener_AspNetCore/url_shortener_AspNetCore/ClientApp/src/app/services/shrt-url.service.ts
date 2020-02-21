import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class ShrtUrlservice {

    constructor(private httpClient: HttpClient) { }

    createShrtUrl(originalUrl: string): Observable<string> {
        return this.httpClient.post<string>('api/urlshortener', originalUrl).pipe(map((response: string) => {
        return response;
         }));
    }
}
