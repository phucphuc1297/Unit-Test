using ProductApp.Models;

namespace ProductApp.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);

        void Delete(int userId);
    }
}
