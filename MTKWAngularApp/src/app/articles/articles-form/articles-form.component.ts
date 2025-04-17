import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { Article, ArticleCreation } from '../articles.models';

@Component({
  selector: 'app-articles-form',
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, RouterLink],
  templateUrl: './articles-form.component.html',
  styleUrl: './articles-form.component.css'
})
export class ArticlesFormComponent implements OnInit {
  private readonly formBuilder = inject(FormBuilder);
  @Input({required: true})
  title!: string;

  @Input()
  model?: Article;

  @Output()
  formPosted = new EventEmitter<ArticleCreation>();

  ngOnInit(): void {
    if(this.model !== undefined){
      this.form.patchValue(this.model as Partial<{ name: string | null; }>);
    }
  }

  form = this.formBuilder.group({
    name: [''],
  })

  saveChanges(){
    const article = this.form.value as ArticleCreation;
    this.formPosted.emit(article);
  }
}
