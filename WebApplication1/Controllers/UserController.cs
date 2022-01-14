using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.HTTPModels;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly UserHandler _userHandler;

        public UserController(IRepository<User> repository, UserHandler userHandler)
        {
            _repository = repository;
            _userHandler = userHandler;
        }
        
        
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(uint id)
        {
            var user = await _repository.GetById(id);

            return Ok(user);
        }
        
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAll();

            return Ok(users);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProfile([FromBody] User user)
        {
            var response = await _userHandler.CreateUser(user);

            return Ok(response);
        }
        
        
    }
}