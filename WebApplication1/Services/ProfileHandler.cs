using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;
using WebApplication1.HTTPModels;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class ProfileHandler
    {
        private readonly IRepository<Profiles> _repository;
        private readonly ILogger<ProfilesController> _logger;
        
        
        public ProfileHandler(IRepository<Profiles> repository)
        {
            _repository = repository;
        }

        public async Task<GenericResponse<Profiles>> CreateProfile(Profiles profile)
        {
            await _repository.Create(profile);

            return new GenericResponse<Profiles>()
            {
                Message = $"The profile with {profile.Id} as Id has been created",
                Data = profile
            };
        }
    }
}