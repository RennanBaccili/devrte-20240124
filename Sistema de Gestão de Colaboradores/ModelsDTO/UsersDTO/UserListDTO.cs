using Sistema_de_Gestão_de_Colaboradores.enums;

namespace Sistema_de_Gestão_de_Colaboradores.UsersDTO
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public StatusUser Status { get; set; }
    }
}
