import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe';
import { RecipeService } from 'src/app/core/services/recipe.service';

@Component({
  selector: 'app-my-recipes',
  templateUrl: './my-recipes.component.html',
  styleUrls: ['./my-recipes.component.scss']
})
export class MyRecipesComponent implements OnInit {
  showAddRecipe = false;
  recipes: Recipe[];

  constructor(
    private recipeService: RecipeService
  ) { }

  ngOnInit() {
    this.getRecipes();
  }

  getRecipes(): void {
    this.recipeService.getRecipes(true).subscribe(recipes => this.recipes = recipes);
  }

  addRecipe(){
    this.showAddRecipe = !this.showAddRecipe;
  }
}
