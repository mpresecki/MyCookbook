using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMicroserviceAPI.Business.Models;
using UserMicroserviceAPI.Data;
using UserMicroserviceAPI.Data.Entities;
using UserMicroserviceAPI.Data.Repositories;
using UserMicroserviceAPI.Helpers;

namespace UserMicroserviceAPI.Business.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;

        private readonly IRepository<User> _userRepository;

        private readonly AppSettings _appSettings;

        public UserService(IMapper mapper, IRepository<User> userRepository, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<List<UserListModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAll()
                .ProjectTo<UserListModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<UserModel> GetUserById(long id)
        {
            var user = await _userRepository.GetAll()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
            user.RejectNotFound();

            return _mapper.Map<UserModel>(user);
        }

        public async Task InsertUser(UserInsertModel user)
        {
            var newUser = _mapper.Map<User>(user);
            await _userRepository.InsertAsync(newUser);
        }

        public async Task UpdateUser(UserListModel user)
        {
            var userEntity =_mapper.Map<User>(user);
            await _userRepository.UpdateAsync(userEntity);
        }

        public async Task DeleteUser(long id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetAll().SingleOrDefault(x => x.Email == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
