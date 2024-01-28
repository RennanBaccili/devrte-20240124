using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestão_de_Colaboradores.Data;
using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.UnitDTO;
using Sistema_de_Gestão_de_Colaboradores.Repositories.Interface;

namespace Sistema_de_Gestão_de_Colaboradores.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly SystemDbContext _dbContext;

        public UnitRepository(SystemDbContext systemDbContext)
        {
            _dbContext = systemDbContext;
        }

        public async Task<List<UnitModel>> FindAllUnitsAsync()
        {
            // Utiliza o método Include para carregar os empregados relacionados com cada unidade
            var unitsWithEmployees = await _dbContext.Units_tab
                                                     .Include(u => u.Employees)
                                                     .ToListAsync();

            return unitsWithEmployees;
        }

        public async Task<UnitModel> RegisterUnitAsync(UnitModel unit)
        {
            _dbContext.Add(unit);

            await _dbContext.SaveChangesAsync();
            return unit;
        }

        public async Task<bool> DeactivyUnitAsync(int id)
        {
            var unit = await _dbContext.Units_tab.FirstOrDefaultAsync(u => u.Id == id);
            if (unit == null)
            {
                return false;
            }

            unit.Status = false;
            _dbContext.Units_tab.Update(unit); 
            await _dbContext.SaveChangesAsync();
            return true; 
        }

        public async Task<bool> ActivateUnitAsync(int id)
        {
            var unit = await _dbContext.Units_tab.FirstOrDefaultAsync(u => u.Id == id);
            if (unit == null)
            {
                return false; 
            }

            unit.Status = true; 
            _dbContext.Units_tab.Update(unit);
            await _dbContext.SaveChangesAsync(); // Persiste as mudanças no banco de dados.
            return true; // Retorna verdadeiro indicando sucesso.
        }
    }
}
