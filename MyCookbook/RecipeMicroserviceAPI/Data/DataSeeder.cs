using RecipeMicroserviceAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data
{
    public class DataSeeder
    {
        public static void SeedData(RecipeContext _context)
        {
            _context.Database.EnsureCreated();
            AddMassUnits(_context);
            AddVolumesUnits(_context);

            AddSkillLevels(_context);
            AddCategories(_context);

            if (!_context.Ingredients.Any())
            {
                var gramUnit = _context.Units.Where(u => u.UnitName == Constants.UNIT_MASS_GRAM.Name).FirstOrDefault();
                var pieceUnit = _context.Units.Where(u => u.UnitName == Constants.UNIT_PIECE.Name).FirstOrDefault();
                _context.Ingredients.Add(new Entities.Ingredient { Name = "egg" });
                _context.Ingredients.Add(new Entities.Ingredient { Name = "flour" });
                _context.Ingredients.Add(new Entities.Ingredient { Name = "sugar" });
                _context.Ingredients.Add(new Entities.Ingredient { Name = "salt" });
            }

            _context.SaveChanges();
        }

        private static void AddMassUnits(RecipeContext _context)
        {
            var existingUnits = _context.Units.Where(u => u.UnitType == UnitType.Mass || u.UnitType == UnitType.Quantity);
            foreach (var unit in requiredMassUnits)
            {
                if (!existingUnits.Select(s => s.UnitName == unit.UnitName).Any())
                {
                    _context.Units.Add(unit);
                }
            }

            _context.SaveChanges();
        }

        private static void AddVolumesUnits(RecipeContext _context)
        {
            var existingUnits = _context.Units.Where(u => u.UnitType == UnitType.Volume);
            foreach (var unit in requiredVolumeUnits)
            {
                if (!existingUnits.Select(s => s.UnitName == unit.UnitName).Any())
                {
                    _context.Units.Add(unit);
                }
            }

            _context.SaveChanges();
        }

        private static void AddSkillLevels(RecipeContext _context)
        {
            var existingSkills = _context.SkillLevels.ToList();
            foreach (var skill in requiredSkills)
            {
                if (!existingSkills.Select(s => s.LevelName == skill.LevelName).Any())
                {
                    _context.SkillLevels.Add(skill);
                }
            }

            _context.SaveChanges();
        }

        private static void AddCategories(RecipeContext _context)
        {
            var existingCategories = _context.RecipeCategories.ToList();
            foreach (var category in requiredCategories)
            {
                if (!existingCategories.Select(s => s.CategoryName == category.CategoryName).Any())
                {
                    _context.RecipeCategories.Add(category);
                }
            }

            _context.SaveChanges();
        }
    
        private static SkillLevel[] requiredSkills = new SkillLevel[]
        {
            new SkillLevel { LevelName = Constants.SKILL_EASY },
            new SkillLevel { LevelName = Constants.SKILL_MEDIUM },
            new SkillLevel { LevelName = Constants.SKILL_HARD }
        };

        private static RecipeCategory[] requiredCategories = new RecipeCategory[]
        {
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_WARM_APPETIZER },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_COLD_APPETIZER },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_MAIN_DISH },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_SIDE_DISH },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_SALADS },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_DESSERT },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_SAUCES },
            new Entities.RecipeCategory { CategoryName = Constants.CATEGORY_SOUPS }
        };

        private static Unit[] requiredMassUnits = new Unit[]
        {
            new Unit {
                    UnitName = Constants.UNIT_MASS_GRAM.Name,
                    UnitAbbreviation = Constants.UNIT_MASS_GRAM.Abbreviation,
                    UnitType = Entities.UnitType.Mass
                },
            new Unit {
                    UnitName = Constants.UNIT_MASS_DECAGRAM.Name,
                    UnitAbbreviation = Constants.UNIT_MASS_DECAGRAM.Abbreviation,
                    UnitType = Entities.UnitType.Mass
                },
            new Unit {
                    UnitName = Constants.UNIT_MASS_KILOGRAM.Name,
                    UnitAbbreviation = Constants.UNIT_MASS_KILOGRAM.Abbreviation,
                    UnitType = Entities.UnitType.Mass
                },
            new Unit {
                    UnitName = Constants.UNIT_MASS_MILLIGRAM.Name,
                    UnitAbbreviation = Constants.UNIT_MASS_MILLIGRAM.Abbreviation,
                    UnitType = Entities.UnitType.Mass
                },
            new Unit {
                    UnitName = Constants.UNIT_MASS_POUND.Name,
                    UnitAbbreviation = Constants.UNIT_MASS_POUND.Abbreviation,
                    UnitType = Entities.UnitType.Mass
                },
            new Unit {
                    UnitName = Constants.UNIT_PIECE.Name,
                    UnitAbbreviation = Constants.UNIT_PIECE.Abbreviation,
                    UnitType = Entities.UnitType.Quantity
                }
        };

        private static Unit[] requiredVolumeUnits = new Unit[]
        {
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_MILLILITER.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_MILLILITER.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_LITER.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_LITER.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_DECILITER.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_DECILITER.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_TEASPOON.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_TEASPOON.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_TABLESPOON.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_TABLESPOON.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_CUP.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_CUP.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_PINT.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_PINT.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
            new Entities.Unit
                {
                    UnitName = Constants.UNIT_VOLUME_FLUID_OUNCE.Name,
                    UnitAbbreviation = Constants.UNIT_VOLUME_FLUID_OUNCE.Abbreviation,
                    UnitType = Entities.UnitType.Volume
                },
        };

    }
}
