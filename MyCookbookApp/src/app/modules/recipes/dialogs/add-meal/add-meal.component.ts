import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MealTypes, MealInsertModel } from 'src/app/shared/models/meal';
import { FormControl } from '@angular/forms';
import { MealService } from 'src/app/core/services/meal.service';
import { Recipe } from 'src/app/shared/models/recipe';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

export interface DialogData {
  id: number;
  recipeId: number;
  recipeName: string;
  mealType: number;
  mealDate: Date;
  minDate: Date;
  maxDate: Date;
}

@Component({
  selector: 'app-add-meal',
  templateUrl: './add-meal.component.html',
  styleUrls: ['./add-meal.component.scss']
})
export class AddMealComponent implements OnInit {
  mealTypes = MealTypes;
  currentUser: User;
  isSaving = false;

  constructor(
    public dialogRef: MatDialogRef<AddMealComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private mealService: MealService,
    private authenticationService: AuthenticationService) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }

  ngOnInit() {
  }

  onSaveClick(): void {
    this.isSaving = true;
    if (this.data.mealDate != null && this.data.mealType != null) {
      const meal = new MealInsertModel();
      meal.recipeId = this.data.recipeId;
      meal.mealType = this.data.mealType;
      meal.mealDay = new Date(this.data.mealDate.getFullYear(), this.data.mealDate.getMonth(), this.data.mealDate.getDate(), 2, 0, 0);
      meal.userId = this.currentUser.id;

      if (this.data.id == null){
        this.mealService.addMeal(meal).subscribe(_ => {
          this.isSaving = false;
          this.dialogRef.close(this.data);
        });
      }
      else{
        meal.id = this.data.id;
        this.mealService.updateMeal(meal).subscribe(_ => {
          this.isSaving = false;
          this.dialogRef.close(this.data);
        });
      }
    }
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onDeleteClick(): void {
    this.isSaving = true;
    this.mealService.deleteMeal(this.data.id).subscribe(_ => {
      this.isSaving = false;
      this.dialogRef.close(this.data);
    });
  }
}
