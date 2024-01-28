using Sistema_de_Gestão_de_Colaboradores.enums;

namespace Sistema_de_Gestão_de_Colaboradores.Models
{
    public class UserModel
    {
        public int Id { get; private set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public StatusUser Status { get; set; }

        public UserModel() { }

        public UserModel(string login, string password)
        {
            Login = login;
            Password = password;
            Status = StatusUser.Active;
        }
    }
}