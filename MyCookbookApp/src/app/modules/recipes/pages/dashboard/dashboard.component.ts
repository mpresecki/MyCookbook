import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe';
import { RecipeService } from 'src/app/core/services/recipe.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  showAddRecipe = false;
  recipes: Recipe[];

  constructor(
    private recipeService: RecipeService
  ) { }

  ngOnInit() {
    this.getRecipes();
  }

  getRecipes(): void {
    this.recipeService.getRecipes().subscribe(recipes => this.recipes = recipes);
  }

  addRecipe(){
    this.showAddRecipe = !this.showAddRecipe;
  }

}
