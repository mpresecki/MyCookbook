export interface Recipe {
    id: number;
    name: string;
    cookingTime: number;
    servings: number;
    isPublic: boolean;
    isSaved: boolean;
    categoryName: string;
    skillLevel: string;
}

export class RecipeInsert{
    id: number;
    name: string;
    cookingTime: number;
    servings: number;
    isPublic: boolean;
    recipeCategoryId: number;
    skillLevelId: number;
    userId: number;

    preparationSteps: [{
        stepNumber: number;
        stepText: string;
    }];

    recipeIngredients: [{
        ingredientId: number;
        unitId: number;
        quantity: number;
    }];
}

export class RecipeModel implements Recipe{
    id: number;
    name: string;
    cookingTime: number;
    servings: number;
    isPublic: boolean;
    isSaved: boolean;
    categoryName: string;
    skillLevel: string;
    userId: number;

    preparationSteps: [{
        stepNumber: number;
        stepText: string;
    }];

    recipeIngredients: [{
        ingredient: string;
        unit: string;
        quantity: number;
    }];
}

export class CookbookRecipe {
    id: number;
    recipe: Recipe;
    userName: string;
    savedAt: Date;
}
