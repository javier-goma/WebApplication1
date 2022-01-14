using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfileHandler _profileHandler;

        public ProfilesController(ProfileHandler profileHandler)
        {
            _profileHandler = profileHandler;
        }
        
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(uint id)
        {
            var response = await _profileHandler.GetProfileById(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await _profileHandler.GetAllProfiles();

            return Ok(profiles);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProfile([FromBody] Profile profile)
        {
            var response = await _profileHandler.CreateProfile(profile);

            return Ok(response);
        }
        
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] Profile profile)
        {
            var response = await _profileHandler.UpdateProfile(profile);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteProfile(uint id)
        {
            var response = await _profileHandler.DeleteProfile(id);

            return Ok(response);
        }
    }
}