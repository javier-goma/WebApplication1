﻿using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication1.Dto;
using WebApplication1.HTTPModels;
using WebApplication1.Models;
using WebApplication1.Repository;

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

        public async Task<GenericResponse<UserDto>> CreateUser(User user)
        {
            var response = await _repository.Create(user);

            if (response != null)
            {
                var temp = new UserDto(user);
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
    }
}