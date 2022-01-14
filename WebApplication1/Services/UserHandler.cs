using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApplication1.Repository;
using WebApplication1.HTTPModels;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Dto;

namespace WebApplication1.Services
{
    public class UserHandler
    {
        private readonly IRepository<User> _repository;
        private readonly ILogger<UserHandler> _logger;

        public UserHandler(IRepository<User> repository, ILogger<UserHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GenericResponse<UserDto>> GetUserById(uint id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return new GenericResponse<UserDto>()
                {
                    Message = $"There is no user with {id} as id",
                    Data = null
                };
            }

            return new GenericResponse<UserDto>()
            {
                Message = $"User with {id} as id",
                Data = new UserDto(user)
            };
        }
        
        public async Task<GenericResponse<ICollection<User>>> GetAllUsers()
        {
            var users = await _repository.GetAll();

            return new GenericResponse<ICollection<User>>()
            {
                Message = $"{users.Count} users were retrieved",
                Data = users
            };
        }
        
        public async Task<GenericResponse<UserDto>> CreateUser(User user)
        {
            var response = await _repository.Create(user);

            if (response != null)
            {
                return new GenericResponse<UserDto>()
                {
                    Message = $"The user with {user.Id} as id has been created",
                    Data = new UserDto(user)
                };  
            }
            
            _logger.LogInformation("User can't be created since profileId doesn't exist on profile table");
            return new GenericResponse<UserDto>()
            {
                Message = "User can not be created since profileId doesn't exist on profile table",
                Data = null
            };
        }
        
        public async Task<GenericResponse<UserDto>> UpdateUser(User user)
        {
            var updatedUser = await _repository.Update(user);

            if (updatedUser == null)
            {
                return new GenericResponse<UserDto>()
                {
                    Message = $"Error while updating: There is no user with {user.Id} as id",
                    Data = null
                };
            }

            var temp = new UserDto(updatedUser);
            return new GenericResponse<UserDto>()
            {
                Message = $"The user with {updatedUser.Id} as Id has been updated",
                Data = new UserDto(updatedUser)
            };
        }


        public async Task<object> DeleteUser(uint id)
        {
            var userToDelete = await _repository.GetById(id);

            if (userToDelete == null)
            {
                return new GenericResponse<Profile>()
                {
                    Message = $"Error while deleting: There is no user with {id} as id",
                    Data = null
                };
            }

            await _repository.Delete(userToDelete);

            return new GenericResponse<Profile>()
            {
                Message = $"The profile with {id} as Id has been deleted",
                Data = null
            };
        }
    }
}