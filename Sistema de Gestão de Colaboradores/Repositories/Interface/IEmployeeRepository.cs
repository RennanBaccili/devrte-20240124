using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.EmployeeDTO;

namespace Sistema_de_Gestão_de_Colaboradores.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> FindAllEmployeeAsync();
        Task<EmployeeModel> RegisterEmployeeAsync(EmployeeModel employee);
        Task<EmployeeModel> UpdateEmployeeAsync(int id, EmployeeUpdateDTO employee);
        Task DeleteEmployeeAsync(int id);
    }
}
