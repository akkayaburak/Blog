using blog.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllWithUser();
        Post GetWithUserById(int id);
        IEnumerable<Post> GetAllWithUserByUserId(int userId);

    }
}
