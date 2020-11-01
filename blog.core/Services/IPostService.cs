using blog.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllWithUser();
        Post GetPostById(int id);
        IEnumerable<Post> GetPostsByUserId(int userId);
        Post CreatePost(Post newPost);
        void UpdatePost(Post postToBeUpdated, Post post);
        void DeletePost(Post post);

        Post GetPostByName(string name);
    }
}
