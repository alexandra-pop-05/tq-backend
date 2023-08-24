using Microsoft.EntityFrameworkCore;
using TQ_Project.Domain.DataAccess;
using TQ_Project.Domain.Entities;
using TQ_Project.Domain.Interfaces;

namespace TQ_Project.Domain.Repositories
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        public UserRepository(EfCoreDbContext context) : base(context)
        {
        }

        public async Task<User>? GetByEmail(string email)
        {
            if(string.IsNullOrEmpty(email)) return null;
            var userEmail = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);    

            return userEmail;
        }
    }
}
