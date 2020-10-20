using blog.core;
using blog.core.Models;
using blog.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.businesslogic
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> CreatePost(Post newPost)
        {
            await _unitOfWork.Posts.AddAsync(newPost);
            await _unitOfWork.CommitAsync();
            return newPost;
        }

        public async Task DeletePost(Post post)
        {
            _unitOfWork.Posts.Remove(post);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Post>> GetAllWithUser()
        {
            return await _unitOfWork.Posts.GetAllWithUserAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _unitOfWork.Posts.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
        {
            return await _unitOfWork.Posts.GetAllWithUserByUserIdAsync(userId);
        }

        public async Task UpdatePost(Post postToBeUpdated, Post post)
        {
            postToBeUpdated.Context = post.Context;
            postToBeUpdated.UserId = post.UserId;
            await _unitOfWork.CommitAsync();
        }
    }
}
