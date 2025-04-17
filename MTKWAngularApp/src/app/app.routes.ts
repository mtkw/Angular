import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { ArticlesListComponent } from './articles/articles-list/articles-list.component';
import { ArticleCreateComponent } from './articles/add-article/add-article.component';
import { ArticlesEditComponent } from './articles/articles-edit/articles-edit.component';

export const routes: Routes = [
    {path: '',  component: LandingComponent},
    {path: 'articles', component: ArticlesListComponent},
    {path: 'articles/create', component: ArticleCreateComponent},
    {path: 'articles/edit/:id', component: ArticlesEditComponent}
];
