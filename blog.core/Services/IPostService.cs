using blog.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllWithUser();
        Task<Post> GetPostById(int id);
        Task<IEnumerable<Post>> GetPostsByUserId(int userId);
        Task<Post> CreatePost(Post newPost);
        Task UpdatePost(Post postToBeUpdated, Post post);
        Task DeletePost(Post post);
    }
}
