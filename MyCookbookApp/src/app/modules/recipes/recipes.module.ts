import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../../shared/shared.module';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './components/recipe-detail/recipe-detail.component';
import { AddRecipeComponent } from './components/add-recipe/add-recipe.component';
import { CookbookComponent } from './pages/cookbook/cookbook.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AddMealComponent } from './dialogs/add-meal/add-meal.component';

const routes: Routes = [
  { path: '', redirectTo: '/recipes', pathMatch: 'full'},
  { path: '', component: DashboardComponent },
  { path: 'my', component: RecipeListComponent },
  { path: 'detail/:id', component: RecipeDetailComponent},
  { path: 'cookbook', component: CookbookComponent}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    SharedModule
  ],
  declarations: [
    RecipeListComponent,
    RecipeDetailComponent,
    AddRecipeComponent,
    CookbookComponent,
    DashboardComponent,
    AddMealComponent
  ]
})
export class RecipesModule { }