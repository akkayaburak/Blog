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

        public IEnumerable<Post> GetAllWithUser()
        {
            return BlogContext.Posts
                .Include(m => m.User)
                .ToList();
        }

        public Post GetWithUserById(int id)
        {
            return  BlogContext.Posts
                .Include(m => m.User)
                .SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Post> GetAllWithUserByUserId(int userId)
        {
            return  BlogContext.Posts
                .Include(m => m.User)
                .Where(m => m.UserId == userId)
                .ToList();
        }
        private BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}
