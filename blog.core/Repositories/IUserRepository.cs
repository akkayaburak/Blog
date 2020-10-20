using blog.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Repositories
{
    public interface IUserRepository : IRepository<User>

    {
        Task<IEnumerable<User>> GetAllWithPostAsync();
        Task<User> GetWithPostsByIdAsync(int id);
    }
}
