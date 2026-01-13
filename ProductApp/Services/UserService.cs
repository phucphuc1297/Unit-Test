using ProductApp.Models;
using ProductApp.Repositories;
using System;

namespace ProductApp.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool IsAdmin(int userId)
        {
            User user = _userRepository.GetUserById(userId);
            return user != null && user.Role == UserRole.Admin;
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            _userRepository.Delete(userId);
        }
    }
}
