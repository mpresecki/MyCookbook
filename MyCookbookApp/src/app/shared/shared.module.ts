import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatTableModule} from '@angular/material/table';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSelectModule} from '@angular/material/select';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatRippleModule} from '@angular/material/core';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatPaginatorModule} from '@angular/material/paginator';

@NgModule({
  imports: [
    CommonModule, FormsModule,
    MatTabsModule, MatGridListModule, MatButtonModule, MatTooltipModule, MatListModule, MatCardModule, MatDividerModule,
    MatFormFieldModule, MatInputModule, MatAutocompleteModule, MatTableModule, MatToolbarModule, MatSelectModule, MatCheckboxModule,
    MatMenuModule, MatIconModule, MatDialogModule, MatDatepickerModule, MatNativeDateModule, MatRippleModule, MatProgressSpinnerModule,
    MatPaginatorModule
  ],
  exports: [
    CommonModule, FormsModule,
    MatTabsModule, MatGridListModule, MatButtonModule, MatTooltipModule, MatListModule, MatCardModule, MatDividerModule,
    MatFormFieldModule, MatInputModule, MatAutocompleteModule, MatTableModule, MatToolbarModule, MatSelectModule, MatCheckboxModule,
    MatMenuModule, MatIconModule, MatDialogModule, MatDatepickerModule, MatNativeDateModule, MatRippleModule, MatProgressSpinnerModule,
    MatPaginatorModule
  ],
  declarations: []
})
export class SharedModule { }
