import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { Ingredient } from 'src/app/shared/models/ingredient';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {
  newIngredient: Ingredient;
  updateIngredient: Ingredient;
  isEditing = false;
  ingredients: Ingredient[];

  dataSource = new MatTableDataSource<Ingredient>(this.ingredients);
  displayedColumns: string[] = ['id', 'name', 'actions'];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private recipeService: RecipeService
  ) {
    this.newIngredient = {
      id: 0,
      name: ''
    };
   }

  ngOnInit() {
    this.getIngredients();
  }

  getIngredients(){
    this.recipeService.getIngredients().subscribe(data => {
      this.ingredients = data;
      this.dataSource = new MatTableDataSource<Ingredient>(this.ingredients);
      this.dataSource.paginator = this.paginator;
    });
  }

  save(){
    if (this.newIngredient.name !== '') {
      this.recipeService.addIngredient(this.newIngredient).subscribe(_ => {
        this.newIngredient.name = '';
        this.getIngredients();
      });
    }
  }

  showUpdateEditor(ingredient: Ingredient){
    this.updateIngredient = {...ingredient};
    this.isEditing = true;
  }

  closeUpdateEditor(){
    this.updateIngredient = null;
    this.isEditing = false;
  }

  update(ingredient: Ingredient){
    this.recipeService.updateIngredient(ingredient).subscribe(_ => {
      this.closeUpdateEditor();
      this.getIngredients();
    });
  }

  delete(id: number){
    this.recipeService.deleteIngredient(id).subscribe(_ => this.getIngredients());
  }
}
