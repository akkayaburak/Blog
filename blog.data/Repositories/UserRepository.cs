using Microsoft.EntityFrameworkCore;
using blog.core.Models;
using blog.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace blog.data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAllWithPost()
        {
            return BlogContext.Users
                .Include(a => a.Posts)
                .ToList();
        }

        public User GetWithPostsById(int id)
        {
            return BlogContext.Users
                .Include(a => a.Posts)
                .SingleOrDefault(a => a.Id == id);
        }

        private BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}
