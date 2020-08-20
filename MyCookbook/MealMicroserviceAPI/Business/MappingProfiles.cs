using AutoMapper;
using MealMicroserviceAPI.Business.Models;
using MealMicroserviceAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Business
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Meal, MealModel>()
                .ForMember(d => d.RecipeName, opt => opt.Ignore());

            CreateMap<MealInsertModel, Meal>();
            CreateMap<MealUpdateModel, Meal>();
        }
    }
}
