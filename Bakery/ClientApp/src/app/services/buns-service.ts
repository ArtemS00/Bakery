import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BUNS_API_URL } from "../app-injection-tokens";
import { Observable } from 'rxjs';
import { Bun } from '../entities/bun';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BunsService {
  constructor(
    private http: HttpClient,
    @Inject(BUNS_API_URL) private bunsUrl: string) {
  }

  getAll() : Observable<Bun[]> {
    return this.http.get<Bun[]>(this.bunsUrl)
      .pipe(map(b =>
        b.map(bun => new Bun(bun))));
  }

  get(id: number): Observable<Bun>{
    return this.http.get<Bun>(this.bunsUrl + id)
      .pipe(map(b => new Bun(b)));
  }
}
