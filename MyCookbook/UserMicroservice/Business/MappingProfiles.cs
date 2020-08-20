using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceAPI.Business.Models;
using UserMicroserviceAPI.Data.Entities;

namespace UserMicroserviceAPI.Business
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserModel>();
            CreateMap<User, UserListModel>();
            CreateMap<UserInsertModel, User>();

            CreateMap<UserRole, UserRoleModel>();
        }
    }
}
