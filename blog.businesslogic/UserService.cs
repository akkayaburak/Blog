using blog.core;
using blog.core.Models;
using blog.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blog.businesslogic
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User CreateUser(User newUser)
        {
             _unitOfWork.Users
                .Add(newUser);
            return newUser;
        }

        public void DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
             _unitOfWork.Commit();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetUserById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public void UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Name = user.Name;
            _unitOfWork.Commit();
        }
    }
}
