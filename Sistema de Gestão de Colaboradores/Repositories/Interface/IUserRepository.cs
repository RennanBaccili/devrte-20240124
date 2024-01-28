using Sistema_de_Gestão_de_Colaboradores.enums;
using Sistema_de_Gestão_de_Colaboradores.Models;

namespace Sistema_de_Gestão_de_Colaboradores.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAllUsersAsync();
        Task<List<UserModel>> FindAllUsersByStatusAsync(StatusUser status);
        Task<UserModel> FindByIdAsync(int id);
        Task<UserModel> RegisterUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(int id, UserModel updatedUser);
    }
}
