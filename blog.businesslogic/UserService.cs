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

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users
                .AddAsync(newUser);
            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Name = user.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
