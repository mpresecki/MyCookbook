export class Meal {
    id: number;
    recipeId: number;
    recipeName: string;
    mealType: number;
    mealDay: Date;
}

export class MealsByDay {
    day: Date;
    meals: Meal[];
}

export class MealInsertModel {
    id: number;
    recipeId: number;
    userId: number;
    mealType: number;
    mealDay: Date;
}

export const MealTypes = [
    { name : 'Breakfast', value : 1 },
    { name : 'Lunch', value : 2 },
    { name : 'Dinner', value : 3 },
    { name : 'Snack', value : 4 }
];
