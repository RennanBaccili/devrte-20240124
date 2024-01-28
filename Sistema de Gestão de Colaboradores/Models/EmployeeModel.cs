using System.Text.Json.Serialization;

namespace Sistema_de_Gestão_de_Colaboradores.Models
{
    public class EmployeeModel
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        // Chave estrangeira para o UserModel
        public int UserId { get; set; }

        // Chave estrangeira para o modelo Unit (Unidade)
        public int UnitId { get; set; }
        // Propriedade de navegação

        [JsonIgnore]
        public virtual UnitModel Unit { get; set; }

    }
}
