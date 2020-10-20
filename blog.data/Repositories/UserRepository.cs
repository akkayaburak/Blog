using Microsoft.EntityFrameworkCore;
using blog.core.Models;
using blog.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> GetAllWithPostAsync()
        {
            return await BlogContext.Users
                .Include(a => a.Posts)
                .ToListAsync();
        }

        public Task<User> GetWithPostsByIdAsync(int id)
        {
            return BlogContext.Users
                .Include(a => a.Posts)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}
