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

        public Post CreatePost(Post newPost)
        {
             _unitOfWork.Posts.Add(newPost);
             _unitOfWork.Commit();
            return newPost;
        }

        public void DeletePost(Post post)
        {
            _unitOfWork.Posts.Remove(post);
            _unitOfWork.Commit();
        }

        public IEnumerable<Post> GetAllWithUser()
        {
            return  _unitOfWork.Posts.GetAllWithUser();
        }

        public Post GetPostById(int id)
        {
            return  _unitOfWork.Posts.GetById(id);
        }

        public IEnumerable<Post> GetPostsByUserId(int userId)
        {
            return  _unitOfWork.Posts.GetAllWithUserByUserId(userId);
        }

        public void UpdatePost(Post postToBeUpdated, Post post)
        {
            postToBeUpdated.Context = post.Context;
            postToBeUpdated.UserId = post.UserId;
             _unitOfWork.Commit();
        }
    }
}
