import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

import { MealService } from 'src/app/core/services/meal.service';
import { Meal, MealsByDay, MealTypes } from 'src/app/shared/models/meal';
import { MatDialog } from '@angular/material/dialog';
import { AddMealComponent } from '../recipes/dialogs/add-meal/add-meal.component';

@Component({
  selector: 'app-meal-planning',
  templateUrl: './meal-planning.component.html',
  styleUrls: ['./meal-planning.component.scss']
})
export class MealPlanningComponent implements OnInit {
  meals: MealsByDay[];
  mealTypes = MealTypes;
  numOfDays = 14;
  days: Date[] = [];
  currentDate = new Date();
  datePipe: DatePipe = new DatePipe('en-US');

  constructor(
    private mealService: MealService,
    public dialog: MatDialog
  ) {
    this.days[0] = new Date();
    for (let index = 1; index < this.numOfDays; index++) {
      const dateInMiliseconds = this.currentDate.setDate(this.currentDate.getDate() + 1);
      const mealDate = new Date(dateInMiliseconds);
      const element = mealDate;
      this.days[index] = element;
    }
    this.currentDate = new Date();
   }

  ngOnInit() {
    this.getMeals();
  }

  findMealsByDay(date: Date){
    const dayString = this.datePipe.transform(date, 'yyyy-MM-dd');
    const mealDate = this.meals != null ? this.meals.find(x => this.datePipe.transform(x.day, 'yyyy-MM-dd') === dayString) : null;
    return mealDate.meals;
  }

  getMeals(){
    this.mealService.getMeals().subscribe(data => {
      this.meals = data;
      for (const day of this.days) {
        const dayString = this.datePipe.transform(day, 'yyyy-MM-dd');
        const mealsOnDay = this.meals.find(m => this.datePipe.transform(m.day, 'yyyy-MM-dd') === dayString);
        if (mealsOnDay == null){
          const m = new MealsByDay();
          m.day = new Date(day);
          m.meals = [];
          this.meals.push(m);
        }
        else {
          mealsOnDay.day = new Date(mealsOnDay.day);
        }
      }
      this.meals.sort((a, b) => a.day.getTime() - b.day.getTime());
    });
  }

  getMealName(type: number){
    return this.mealTypes.find(m => m.value === type).name;
  }

  openDialog(meal: Meal): void {
    const currentDate = new Date();
    const maxDateInMs = currentDate.setDate(currentDate.getDate() + 13);
    const dialogRef = this.dialog.open(AddMealComponent, {
      width: '350px',
      data: {id: meal.id, recipeId: meal.recipeId, recipeName: meal.recipeName,
        mealType: meal.mealType,
        mealDate: meal.mealDay,
        minDate: new Date(), maxDate: new Date(maxDateInMs)}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.getMeals();
    });
  }
}
