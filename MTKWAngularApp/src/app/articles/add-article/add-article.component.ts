import { Component, inject } from '@angular/core';
import {FormBuilder, ReactiveFormsModule} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { ArticlesService } from '../articles.service';
import { ArticleCreation } from '../articles.models';
import { ArticlesFormComponent } from "../articles-form/articles-form.component";


@Component({
  selector: 'app-add-article',
  imports: [ArticlesFormComponent],
  templateUrl: './add-article.component.html',
  styleUrl: './add-article.component.css'
})
export class ArticleCreateComponent {
  articlesService = inject(ArticlesService);
  router = inject(Router);


  saveChanges(article: ArticleCreation) {
    this.articlesService.create(article).subscribe(()=>{
      this.router.navigate(['/articles']);
    });
  }
}
