using blog.core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
