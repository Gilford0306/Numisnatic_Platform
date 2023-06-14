

namespace Numisnatic_Platform.Class
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        List<Monet> monets { get; set; }

        public User()
        {

        }

        public User(int id, string login)
        {
            Id = id;
            Login = login;

        }

    }
}
