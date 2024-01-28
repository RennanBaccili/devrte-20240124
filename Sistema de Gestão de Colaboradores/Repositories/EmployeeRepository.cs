using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestão_de_Colaboradores.Data;
using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.EmployeeDTO;
using Sistema_de_Gestão_de_Colaboradores.Repositories.Interface;

namespace Sistema_de_Gestão_de_Colaboradores.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly SystemDbContext _dbContext;

        public EmployeeRepository(SystemDbContext systemDbContext)
        {
            _dbContext = systemDbContext;
        }


        public async Task<List<EmployeeModel>> FindAllEmployeeAsync()
        {
            return await _dbContext.Employees_tab.ToListAsync();
        }

        public async Task<EmployeeModel> RegisterEmployeeAsync(EmployeeModel employee)
        {
            // Validação dos dados
            if (string.IsNullOrWhiteSpace(employee.Name))
            {
                throw new ArgumentException("Nome do colaborador é obrigatório.");
            }
            // Verificar se o UserId existe no banco de dados
            var userExists = await _dbContext.Users_tab.AnyAsync(u => u.Id == employee.UserId);
            if (!userExists)
            {
                throw new ArgumentException("UserId inválido ou inexistente.");
            }
            // Verificar se o UnitId existe no banco de dados
            var unitExists = await _dbContext.Units_tab.AnyAsync(u => u.Id == employee.UnitId);
            if (!unitExists)
            {
                throw new ArgumentException("UnitId inválido ou inexistente.");
            }
            try
            {
                // Criação do colaborador
                _dbContext.Employees_tab.Add(employee);
                await _dbContext.SaveChangesAsync();

                // Retorna o colaborador criado
                return employee;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao registrar o colaborador.", ex);
            }
        }

        public async Task<EmployeeModel> UpdateEmployeeAsync(int id, EmployeeUpdateDTO employeeUpdateDTO)
        {
            // Busca o colaborador pelo ID
            var employee = await _dbContext.Employees_tab.FindAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException("Colaborador não encontrado.");
            }

            // Verificar se o UnitId existe no banco de dados
            var unitExists = await _dbContext.Units_tab.AnyAsync(u => u.Id == employeeUpdateDTO.UnitId);
            if (!unitExists)
            {
                throw new ArgumentException("UnitId inválido ou inexistente.");
            }

            // Atualiza as propriedades do colaborador
            employee.Name = employeeUpdateDTO.Name;
            employee.UnitId = employeeUpdateDTO.UnitId;

            // Salva as alterações no banco de dados
            _dbContext.Employees_tab.Update(employee);
            await _dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            // Encontra o colaborador pelo ID
            var employee = await _dbContext.Employees_tab.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Colaborador não encontrado para exclusão.");
            }

            // Remove o colaborador do contexto do Entity Framework
            _dbContext.Employees_tab.Remove(employee);

            // Salva as alterações no banco de dados
            await _dbContext.SaveChangesAsync();
        }
    }
}
