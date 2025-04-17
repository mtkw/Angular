import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import { Article, ArticleCreation } from './articles.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {

  constructor() { }
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + '/api/articles';

  public getAll(): Observable<Article[]> {
    return this.http.get<Article[]>(`${this.apiUrl}`);
  };

  public getById(id: number): Observable<Article> {
    return this.http.get<Article>(`${this.apiUrl}/${id}`);
  }


  public create(article: ArticleCreation){
    return this.http.post(`${this.apiUrl}`, article);
  }

  public update(id: number, article: ArticleCreation){
    return this.http.put(`${this.apiUrl}/${id}`, article);
  }

  public delete(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
