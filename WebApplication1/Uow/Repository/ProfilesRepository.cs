using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using WebApplication1.Db;

namespace WebApplication1.Uow.Repository
{
    public class ProfilesRepository : BaseRepository<Profile>
    {
        private readonly WebApplicationContext _dbContext;

        public ProfilesRepository(WebApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Profile> Update(Profile entity)
        {
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.Id == entity.Id);

            if (profile == null)
            {
                return null;
            }
            
            profile.ProfileName = entity.ProfileName;
            await _dbContext.SaveChangesAsync();

            return profile;

        }
    }
}