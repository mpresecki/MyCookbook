import { Component, OnInit } from '@angular/core';
import { CookbookRecipe, Recipe } from 'src/app/shared/models/recipe';
import { CookbookService } from 'src/app/core/services/cookbook.service';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-cookbook',
  templateUrl: './cookbook.component.html',
  styleUrls: ['./cookbook.component.scss']
})
export class CookbookComponent implements OnInit {
  cookbookRecipes: CookbookRecipe[];
  recipes: Recipe[] = [];
  private currentUser: User;

  constructor(
    private cookbookService: CookbookService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.getCookbookRecipes();
  }

  getCookbookRecipes(){
    this.cookbookService.getCookbookRecipes().subscribe(data => {
      this.cookbookRecipes = data;
      this.cookbookRecipes.forEach(element => {
        this.recipes.push(element.recipe);
      });
    });
  }

  saveToCookbook(recipeId: number){
    this.cookbookService.addCookbookRecipe(recipeId, this.currentUser.id)
      .subscribe(_ => location.reload());
  }

  removeFromCookbook(recipeId: number){
    this.cookbookService.deleteCookbookRecipe(recipeId, this.currentUser.id)
      .subscribe(_ => location.reload());
  }
}
