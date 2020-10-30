using blog.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Repositories
{
    public interface IUserRepository : IRepository<User>

    {
        IEnumerable<User> GetAllWithPost();
        User GetWithPostsById(int id);
    }
}
