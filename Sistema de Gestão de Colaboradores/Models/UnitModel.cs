using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sistema_de_Gestão_de_Colaboradores.Models
{
    public class UnitModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int UnitCode { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }


        public UnitModel(int UnitCode, string Name)
        {
            this.UnitCode = UnitCode;
            this.Name = Name;
            this.Status = true;
        }

        public UnitModel()
        {
        }
 
        public virtual ICollection<EmployeeModel> Employees { get; set; }

    }
}
