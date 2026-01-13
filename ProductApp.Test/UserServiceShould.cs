using NSubstitute;
using NSubstitute.ReturnsExtensions;
using ProductApp.Models;
using ProductApp.Repositories;
using ProductApp.Services;

namespace ProductApp.Tests
{
    public class UserServiceShould
    {
        private IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private UserService _userService;

        public UserServiceShould()
        {
            _userService = new UserService(_userRepository);
        }

        #region IsAdmin

        [Fact]
        public void IsUserAdmin_WhenUserIsAdmin_ReturnsTrue()
        {
            // Arrange
            int userId = 1;

            var user = new User() { Id = userId, Role = UserRole.Admin };
            _userRepository.GetUserById(userId).Returns(user);

            // Act
            bool result = _userService.IsAdmin(userId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUserAdmin_WhenUserIsNotAdmin_ReturnsFalse()
        {
            // Arrange
            int userId = 1;

            var user = new User() { Id = userId, Role = UserRole.User };
            _userRepository.GetUserById(userId).Returns(user);

            // Act
            bool result = _userService.IsAdmin(userId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsUserAdmin_WhenUserIsNotFound_ReturnsFalse()
        {
            // Arrange
            int userId = 1;
            _userRepository.GetUserById(userId).ReturnsNull();

            // Act
            bool result = _userService.IsAdmin(userId);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region DeleteUser

        [Fact(Skip = "Skip")]
        public void DeleteUser_ThrowsExceptionIfUserNotFound()
        {
            // Arrange
            int userId = 1;
            _userRepository.GetUserById(userId).ReturnsNull();

            // Act
            var exception = Assert.Throws<Exception>(() => _userService.DeleteUser(userId));

            // Assert
            Assert.Equal("User Not Found", exception.Message);
        }

        [Fact]
        public void DeleteUser_VerifiesThatDeleteUserRepositoryWasCalled()
        {
            // Arrange
            int userId = 1;

            var user = new User { Id = userId };
            _userRepository.GetUserById(userId).Returns(user);

            // Act
            _userService.DeleteUser(userId);

            // Assert
            _userRepository.Received(1).Delete(userId);
        }

        #endregion
    }
}
