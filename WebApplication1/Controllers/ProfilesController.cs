using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Services;
using WebApplication1.Uow.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly IRepository<Profiles> _repository;
        private readonly ProfileHandler _profileHandler;
        private readonly ILogger<ProfilesController> _logger;
        
        
        public ProfilesController(IRepository<Profiles> repository, ProfileHandler profileHandler)
        {
            _repository = repository;
            _profileHandler = profileHandler;
        }
        
        [HttpGet]
        [Route("get/{id}")]
        public async Task<Profiles> GetById(uint id)
        {
            var profile = await _repository.GetById(id);

            return profile;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProfile([FromBody] Profiles profile)
        {
            var response = await _profileHandler.CreateProfile(profile);

            return Ok(response);
        }
        
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] Profiles profile)
        {
            await _repository.Update(profile);

            return Ok("Profile has been updated");
        }

    }
}