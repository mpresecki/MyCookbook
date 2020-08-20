import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';
import { MealPlanningComponent } from './meal-planning.component';

const routes: Routes = [
  { path: '', redirectTo: '/meals', pathMatch: 'full'},
  { path: '', component: MealPlanningComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ],
  declarations: [MealPlanningComponent]
})
export class MealPlanningModule { }
