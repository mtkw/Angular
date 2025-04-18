import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { Article, ArticleCreation } from '../articles.models';
import { ArticlesService } from '../articles.service';
import { Router } from '@angular/router';
import { ArticlesFormComponent } from "../articles-form/articles-form.component";


@Component({
  selector: 'app-articles-edit',
  imports: [ArticlesFormComponent],
  templateUrl: './articles-edit.component.html',
  styleUrl: './articles-edit.component.css'
})
export class ArticlesEditComponent implements OnInit {

 @Input({transform: numberAttribute})
  id!: number;

  article?: Article;

  articelService = inject(ArticlesService);
router = inject(Router);  

  ngOnInit(): void {
   this.articelService.getById(this.id).subscribe((article) => {
      this.article = article;
    });
  }

  saveChanges(article: ArticleCreation) {
    this.articelService.update(this.id, article).subscribe(() => {
      this.router.navigate(['/articles']);
    });
  }
}
