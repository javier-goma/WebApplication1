using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;
using WebApplication1.Repository;
using WebApplication1.HTTPModels;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Uow.Repository;

namespace WebApplication1.Services
{
    public class ProfileHandler
    {
        private readonly IRepository<Profile> _repository;
        private readonly ILogger<ProfilesController> _logger;
        
        
        public ProfileHandler(IRepository<Profile> repository)
        {
            _repository = repository;
        }

        public async Task<GenericResponse<Profile>> GetProfileById(uint id)
        {
            var profile = await _repository.GetById(id);

            if (profile == null)
                return new GenericResponse<Profile>()
                {
                    Message = $"The profile with {id} as Id does not exist",
                    Data = null
                };

            return new GenericResponse<Profile>()
            {
                Message = $"Profile with {profile.Id} as Id",
                Data = profile
            };
        }

        public async Task<GenericResponse<ICollection<Profile>>> GetAllProfiles()
        {
            var profiles = await _repository.GetAll();

            return new GenericResponse<ICollection<Profile>>()
            {
                Message = $"{profiles.Count} profiles were retrieved",
                Data = profiles
            };
        }
        
        public async Task<GenericResponse<Profile>> CreateProfile(Profile profile)
        {
            await _repository.Create(profile);

            return new GenericResponse<Profile>()
            {
                Message = $"The profile with {profile.Id} as Id has been created",
                Data = profile
            };
        }

        public async Task<GenericResponse<Profile>> UpdateProfile(Profile profile)
        {
            var updatedProfile = await _repository.Update(profile);

            if (updatedProfile == null)
            {
                return new GenericResponse<Profile>()
                {
                    Message = $"Error while updating: There is no profile with {profile.Id} as id",
                    Data = null
                };
            }
            return new GenericResponse<Profile>()
            {
                Message = $"The profile with {profile.Id} as Id has been updated",
                Data = profile
            };
        }

        public async Task<GenericResponse<Profile>> DeleteProfile(uint id)
        {
            var profileToDelete = await _repository.GetById(id);

            if (profileToDelete == null)
            {
                return new GenericResponse<Profile>()
                {
                    Message = $"Error while deleting: There is no profile with {id} as id",
                    Data = null
                };
            }

            await _repository.Delete(profileToDelete);

            return new GenericResponse<Profile>()
            {
                Message = $"The profile with {id} as Id has been deleted",
                Data = null
            };
        }
    }
}