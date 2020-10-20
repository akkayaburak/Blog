using blog.core.Models;
using blog.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Post>> GetAllWithUserAsync()
        {
            return await BlogContext.Posts
                .Include(m => m.User)
                .ToListAsync();
        }

        public async Task<Post> GetWithUserByIdAsync(int id)
        {
            return await BlogContext.Posts
                .Include(m => m.User)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Post>> GetAllWithUserByUserIdAsync(int userId)
        {
            return await BlogContext.Posts
                .Include(m => m.User)
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }
        private BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}
