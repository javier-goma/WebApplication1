using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
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

        public override async Task<User> Create(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            user.LastLogin = DateTime.Now;

            if (!await ProfileExists(user.ProfileId)) return null;
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public override async Task<User> Update(User entity)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == entity.Id);

            if (user == null)
            {
                return null;
            }

            user.Password = user.Password;
            user.Status = user.Status;
            user.Username = entity.Username;
            user.ProfileId = entity.ProfileId;
            user.UpdateDate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return user;
        }

        private async Task<bool> ProfileExists(uint id)
        {
            return (await _dbContext.Profiles.FirstOrDefaultAsync(p => p.Id == id)) != null;
        }
    }
}