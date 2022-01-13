using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using WebApplication1.Db;

namespace WebApplication1.Uow.Repository
{
    public class ProfilesRepository : BaseRepository<Profiles>
    {
        private readonly WebApplicationContext _dbContext;

        public ProfilesRepository(WebApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Profiles> GetProfileById(uint id)
        {
            return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}