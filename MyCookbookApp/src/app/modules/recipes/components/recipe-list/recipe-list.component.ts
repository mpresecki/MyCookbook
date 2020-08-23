import { Component, OnInit, Input } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { CookbookService } from 'src/app/core/services/cookbook.service';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit {
  @Input()
  recipes: Recipe[];

  isSaving = false;

  private currentUser: User;

  constructor(
    private recipeService: RecipeService,
    private cookbookService: CookbookService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  deleteRecipe(recipeId: number){
    this.recipeService.deleteRecipe(recipeId).subscribe();
  }

  saveToCookbook(recipeId: number){
    this.isSaving = true;
    this.cookbookService.addCookbookRecipe(recipeId, this.currentUser.id)
      .subscribe(_ => {
        this.isSaving = false;
        location.reload();
      });
  }

  removeFromCookbook(recipeId: number){
    this.isSaving = true;
    this.cookbookService.deleteCookbookRecipe(recipeId, this.currentUser.id)
      .subscribe(_ => {
        this.isSaving = false;
        location.reload();
      });
  }
}
