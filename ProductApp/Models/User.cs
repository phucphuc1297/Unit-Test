namespace ProductApp.Models
{
    public class User
    {
        private int _id;
        private string _name;
        private UserRole _role;

        public User()
        {

        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public UserRole Role { get { return _role; } set { _role = value; } }
    }

    public enum UserRole
    {
        User,
        Admin
    }
}
