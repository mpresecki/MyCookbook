import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SkillTypes, Skill } from 'src/app/shared/models/skill-types';
import { RecipeCategories, RecipeCategory } from 'src/app/shared/models/recipe-category';
import { UnitTypes, Unit } from 'src/app/shared/models/unit-types';
import { Ingredient } from 'src/app/shared/models/ingredient';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { RecipeInsert, Recipe, RecipeModel } from 'src/app/shared/models/recipe';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { ArrayType } from '@angular/compiler';
import { FormGroup, FormBuilder, FormArray, Form, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.scss']
})
export class AddRecipeComponent implements OnInit {
  recipeForm: FormGroup;
  ingredientsForm: FormGroup;
  ingredientsFormArray: FormArray;
  prepStepsForm: FormGroup;
  prepStepsFormArray: FormArray;

  currentUser: User;
  skillTypes: Skill[];
  recipeCategories: RecipeCategory[];
  unitTypes: Unit[];

  foundIngredients$: Observable<Ingredient[]>;
  private searchTerms = new Subject<string>();

  recipe: RecipeInsert = new RecipeInsert();

  isSaving = false;

  @Input()
  recipeEdit: RecipeModel = null;

  @Output()
  showEditor = new EventEmitter<boolean>();

  constructor(
    private recipeService: RecipeService,
    private authenticationService: AuthenticationService,
    private fb: FormBuilder
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    this.recipeForm = this.fb.group({
      recipeName: ['', [Validators.required]],
      servings: [[Validators.required]],
      cookingTime: [[Validators.required]],
      isPublic: [true, []],
      skillLevel: [Validators.required],
      category: [Validators.required]
    });

    const newIngredientsForm = this.fb.group({
      formArray: this.fb.array([])
    });
    const newPrepStepsForm = this.fb.group({
      formArray: this.fb.array([])
    });

    this.ingredientsForm = newIngredientsForm;
    this.ingredientsFormArray = newIngredientsForm.controls.formArray as FormArray;
    this.ingredientsFormArray.push(this.fb.group({
      ingredientId: ['Ingredient', [Validators.required]],
      unitId: ['Unit', [Validators.required]],
      quantity: ['Quantity', [Validators.required]]
    }));

    this.prepStepsForm = newPrepStepsForm;
    this.prepStepsFormArray = newPrepStepsForm.controls.formArray as FormArray;
    this.prepStepsFormArray.push(this.fb.group({
      stepText: ['', [Validators.required, Validators.minLength(5)]],
      stepNumber: [1]
    }));
  }

  async ngOnInit() {
    this.recipe.recipeIngredients = [{ingredientId: 0, unitId: 0, quantity: 1}];
    this.recipe.preparationSteps = [{stepNumber: 1, stepText: ''}];

    this.recipeCategories = await this.recipeService.getRecipeCategories().toPromise();
    this.skillTypes = await this.recipeService.getSkillLevels().toPromise();
    this.unitTypes = await this.recipeService.getUnits().toPromise();

    if (this.recipeEdit != null) {
      this.initRecipeEdit();
    }

    this.foundIngredients$ = this.searchTerms.pipe(
      debounceTime(300),

      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.recipeService.searchIngredients(term)),
    );
  }

  search(term: string): void {
    this.searchTerms.next(term);
  }

  displayFn(ingr: Ingredient): string {
    return ingr && ingr.name ? ingr.name : '';
  }

  save(){
    this.isSaving = true;

    this.recipe.userId = this.currentUser.id;
    this.recipe.name = this.recipeForm.value.recipeName;
    this.recipe.servings = this.recipeForm.value.servings;
    this.recipe.recipeCategoryId = this.recipeForm.value.category;
    this.recipe.skillLevelId = this.recipeForm.value.skillLevel;
    this.recipe.cookingTime = this.recipeForm.value.cookingTime;
    this.recipe.isPublic = this.recipeForm.value.isPublic;

    this.ingredientsFormArray.value.forEach(element => {
        element.ingredientId = element.ingredientId.id;
    });
    this.recipe.recipeIngredients = this.ingredientsFormArray.value;
    this.recipe.preparationSteps = this.prepStepsFormArray.value;

    if (this.recipeEdit != null) {
      console.log(this.recipe);
      this.recipeService.updateRecipe(this.recipe).subscribe(_ => {
        this.isSaving = false;
        this.showEditor.emit(false);
        location.reload();
      });
    }
    else {
      this.recipeService.addRecipe(this.recipe).subscribe(_ => {
        this.isSaving = false;
        this.showEditor.emit(false);
        location.reload();
      });
    }
  }

  initRecipeEdit(){
    this.recipe.id = this.recipeEdit.id;
    const skillLevelId = this.skillTypes.find(s => s.levelName === this.recipeEdit.skillLevel).id;
    const recipeCategoryId = this.recipeCategories.find(s => s.categoryName === this.recipeEdit.categoryName).id;

    this.recipeForm = this.fb.group({
      recipeName: [this.recipeEdit.name, [Validators.required]],
      servings: [this.recipeEdit.servings, [Validators.required]],
      cookingTime: [this.recipeEdit.cookingTime, [Validators.required]],
      isPublic: [this.recipeEdit.isPublic, []],
      skillLevel: [skillLevelId, [Validators.required]],
      category: [recipeCategoryId, [Validators.required]]
    });

    this.ingredientsFormArray.removeAt(0);
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.recipeEdit.recipeIngredients.length; i++) {
      const element = this.recipeEdit.recipeIngredients[i];
      const unitId = this.unitTypes.find(s => s.unitName.toLowerCase() === element.unit.toLowerCase()).id;
      this.recipeService.searchIngredients(element.ingredient, true).subscribe(data => {
        const ingr = data[0];
        this.ingredientsFormArray.push(this.fb.group({
          ingredientId: [ingr, [Validators.required]],
          unitId: [unitId, [Validators.required]],
          quantity: [element.quantity, [Validators.required]]
        }));
      });
    }

    this.prepStepsFormArray.removeAt(0);
    this.recipeEdit.preparationSteps.forEach(element => {
      this.prepStepsFormArray.push(this.fb.group({
        stepText: [element.stepText, [Validators.required, Validators.minLength(5)]],
        stepNumber: [element.stepNumber]
      }));
    });
  }

  addIngredient(): void {
    const arrayControl = this.ingredientsForm.controls.formArray as FormArray;
    const newGroup = this.fb.group({
      ingredientId: ['Ingredient', [Validators.required]],
      unitId: ['Unit', [Validators.required]],
      quantity: ['Quantity', [Validators.required]]
    });
    arrayControl.push(newGroup);
  }

  delIngredient(index: number): void {
      const arrayControl = this.ingredientsForm.controls.formArray as FormArray;
      arrayControl.removeAt(index);
  }

  addPrepStep(): void {
    const arrayControl = this.prepStepsForm.controls.formArray as FormArray;
    const newGroup = this.fb.group({
      stepText: ['', [Validators.required, Validators.minLength(5)]],
      stepNumber: [arrayControl.length + 1]
    });
    arrayControl.push(newGroup);
  }

  delPrepStep(index: number): void {
      const arrayControl = this.prepStepsForm.controls.formArray as FormArray;
      arrayControl.removeAt(index);
  }
}
