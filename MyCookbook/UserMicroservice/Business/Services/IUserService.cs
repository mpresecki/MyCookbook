using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceAPI.Business.Models;
using UserMicroserviceAPI.Data.Entities;

namespace UserMicroserviceAPI.Business.Services
{
    public interface IUserService
    {
        Task<List<UserListModel>> GetAllUsersAsync();

        Task<UserModel> GetUserById(long id);

        Task InsertUser(UserInsertModel user);

        Task UpdateUser(UserListModel user);

        Task DeleteUser(long id);

        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
