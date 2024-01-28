using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.UnitDTO;

namespace Sistema_de_Gestão_de_Colaboradores.Repositories.Interface
{
    public interface IUnitRepository
    {
        //Listagem de Unidades: O sistema deve permitir listar todas as unidades cadastradas e todos os colaboradores relacionadados.
        Task<List<UnitModel>> FindAllUnitsAsync();
        Task<UnitModel> RegisterUnitAsync(UnitModel unit);
        Task<bool> DeactivyUnitAsync(int id);
        Task<bool> ActivateUnitAsync(int id);
    }
}
