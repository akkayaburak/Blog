using blog.core;
using blog.core.Repositories;
using blog.data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        private PostRepository _postRepository;
        private UserRepository _userRepository;

        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }

        public IPostRepository Posts => _postRepository ??= new PostRepository(_context);
        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
