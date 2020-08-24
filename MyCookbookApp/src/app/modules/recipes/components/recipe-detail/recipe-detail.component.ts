import { Component, OnInit } from '@angular/core';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { RecipeModel, Recipe } from 'src/app/shared/models/recipe';
import { MatDialog } from '@angular/material/dialog';
import { AddMealComponent } from '../../dialogs/add-meal/add-meal.component';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.scss']
})
export class RecipeDetailComponent implements OnInit {
  recipe: RecipeModel = new RecipeModel();
  showEditRecipe = false;
  currentUser: User;

  constructor(
    private recipeService: RecipeService,
    private authenticationService: AuthenticationService,
    private location: Location,
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.getRecipe();
  }

  editRecipe(){
    this.showEditRecipe = !this.showEditRecipe;
  }

  getRecipe(){
    const id = +this.route.snapshot.paramMap.get('id');
    if (id){
      this.recipeService.getRecipe(id).subscribe(data => this.recipe = data);
    }
  }

  deleteRecipe(){
    this.recipeService.deleteRecipe(this.recipe.id).subscribe(_ => this.location.back());
  }

  openDialog(recipe: Recipe): void {
    const currentDate = new Date();
    const maxDateInMs = currentDate.setDate(currentDate.getDate() + 13);
    const dialogRef = this.dialog.open(AddMealComponent, {
      width: '350px',
      data: {recipeId: recipe.id, recipeName: recipe.name, minDate: new Date(), maxDate: new Date(maxDateInMs)}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      const meal = result;
      console.log(result);
    });
  }
}
