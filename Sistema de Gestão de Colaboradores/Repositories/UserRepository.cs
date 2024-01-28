using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestão_de_Colaboradores.Data;
using Sistema_de_Gestão_de_Colaboradores.enums;
using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.Repositories.Interface;

namespace Sistema_de_Gestão_de_Colaboradores.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemDbContext _dbContext;

        public UserRepository(SystemDbContext systemDbContext)
        {
            _dbContext = systemDbContext;
        }

        public async Task<List<UserModel>> FindAllUsersAsync()
        {
            //Para retornar todos os Users
            return await _dbContext.Users_tab.ToListAsync();
        }

        public async Task<UserModel> FindByIdAsync(int id)
        {
            return await _dbContext.Users_tab.FirstOrDefaultAsync((u) => id == u.Id);
        }

        public async Task<UserModel> RegisterUserAsync(UserModel user)
        {
            // Adiciona o usuário ao contexto do Entity Framework
            _dbContext.Users_tab.Add(user);

            // Salva as alterações no banco de dados de forma assíncrona
            await _dbContext.SaveChangesAsync();

            // Retorna o usuário que foi adicionado com o ID preenchido (presumindo que o ID é gerado pelo banco de dados)
            return user;
        }

        public async Task<UserModel> UpdateUserAsync(int id,UserModel updatedUser)
        {
            var existingUser = await _dbContext.Users_tab.FindAsync(id);

            if (existingUser == null)
            {
                // Se o usuário não existir, você pode lançar uma exceção, retornar null ou tomar outra ação apropriada.
                throw new ArgumentException("Usuário não encontrado.");
            }

            existingUser.Password = updatedUser.Password;
            existingUser.Status = updatedUser.Status;

            await _dbContext.SaveChangesAsync();
 
            return existingUser;
        }

        //busca todos os Users de acordo com seu status
        public async Task<List<UserModel>> FindAllUsersByStatusAsync(StatusUser status)
        {
            List<UserModel> users = await _dbContext.Users_tab
            .Where(u => u.Status == status)
            .ToListAsync();
            return users;
        }
    }
}
