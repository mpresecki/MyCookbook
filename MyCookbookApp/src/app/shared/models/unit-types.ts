export interface Unit {
    id: number;
    unitName: string;
    unitAbbreviation: string;
    unitType: number;
}

export const UnitTypes = [
    { name : 'Gram', value : 1 },
    { name : 'Decagram', value : 2},
    { name : 'Kilogram', value : 3 },
    { name : 'Miligram', value : 4 },
    { name : 'Pound', value : 5 },
    { name : 'Ounce', value : 6 },

    { name : 'Piece', value : 7 },

    { name : 'Milliliter', value : 8},
    { name : 'Liter', value : 9 },
    { name : 'Deciliter', value : 10 },
    { name : 'Teaspoon', value : 11 },
    { name : 'Tablespoon', value : 12 },
    { name : 'Cup', value : 13 },
    { name : 'Pint', value : 14},
    { name : 'Fluid Ounce', value : 15 }
];
