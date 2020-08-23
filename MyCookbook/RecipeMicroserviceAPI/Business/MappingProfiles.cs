using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeMicroserviceAPI.Business.Models;
using RecipeMicroserviceAPI.Data.Entities;

namespace RecipeMicroserviceAPI.Business
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Recipe, RecipeModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.SkillLevel, opt => opt.MapFrom(src => src.SkillLevel.LevelName))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.RecipeCategory.CategoryName));
            CreateMap<Recipe, RecipeListModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.SkillLevel, opt => opt.MapFrom(src => src.SkillLevel.LevelName))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.RecipeCategory.CategoryName));

            CreateMap<RecipeInsertModel, Recipe>();
            CreateMap<RecipeIngredientInsertModel, RecipeIngredient>();

            CreateMap<RecipeIngredient, RecipeIngredientModel>()
                .ForMember(d => d.Ingredient, opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(d => d.Unit, opt => opt.MapFrom(src => src.Unit.UnitName));

            CreateMap<Ingredient, IngredientModel>();
            CreateMap<IngredientInsertModel, Ingredient>();
            CreateMap<IngredientModel, Ingredient>();

            CreateMap<Unit, UnitModel>();
            CreateMap<RecipeCategory, RecipeCategoryModel>();
            CreateMap<SkillLevel, SkillLevelModel>();

            CreateMap<PreparationStep, PreparationStepModel>();
            CreateMap<PreparationStepModel, PreparationStep>();

            CreateMap<MyCookbook, CookbookModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.Recipe, opt => opt.MapFrom(src => src.Recipe));

            CreateMap<CookbookModel, MyCookbook>();
            CreateMap<CookbookInsertModel, MyCookbook>();
        }
    }
}
