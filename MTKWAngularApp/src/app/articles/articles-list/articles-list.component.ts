import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { ArticlesService } from '../articles.service';
import { Article } from '../articles.models';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-articles-list',
  imports: [MatButtonModule, RouterLink, MatTableModule],
  templateUrl: './articles-list.component.html',
  styleUrl: './articles-list.component.css'
})
export class ArticlesListComponent {
  articleService = inject(ArticlesService);
  articles?: Article[];
  columnsToDisplay = ['id', 'title','categorY_ID','category', 'authoR_ID','author', 'createD_AT', 'actions'];

  constructor() {
this.loadArticles();
  }

loadArticles(){
  this.articleService.getAll().subscribe(articles => {
    this.articles = articles;
  });
}

  delete(id: number) {
    this.articleService.delete(id).subscribe(() => {
      this.articles = this.articles?.filter((article) => article.id !== id);
    });
  }
}
