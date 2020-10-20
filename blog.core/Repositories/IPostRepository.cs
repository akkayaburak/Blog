using blog.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithUserAsync();
        Task<Post> GetWithUserByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllWithUserByUserIdAsync(int userId);

    }
}
