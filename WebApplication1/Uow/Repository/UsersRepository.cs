using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Uow.Repository;
using WebApplication1.Models;
using WebApplication1.Db;

namespace WebApplication1.Repository
{
    public class UsersRepository : BaseRepository<User>
    {
        private readonly WebApplicationContext _dbContext;

        public UsersRepository(WebApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserById(uint id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}