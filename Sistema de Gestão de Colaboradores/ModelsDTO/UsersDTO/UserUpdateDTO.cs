using Sistema_de_Gestão_de_Colaboradores.enums;

namespace Sistema_de_Gestão_de_Colaboradores.ModelsDTO.UsersDTO
{
    public class UserUpdateDTO

    {
        public string Password { get; set; }
        public StatusUser Status { get; set; }
    }
}
