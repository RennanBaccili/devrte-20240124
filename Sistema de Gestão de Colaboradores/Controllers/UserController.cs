using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestão_de_Colaboradores.enums;
using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.UsersDTO;
using Sistema_de_Gestão_de_Colaboradores.Repositories.Interface;
using Sistema_de_Gestão_de_Colaboradores.UsersDTO;

namespace Sistema_de_Gestão_de_Colaboradores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }

        //Método para retornar todos os Users
        [HttpGet]
        public async Task<ActionResult<List<UserListDTO>>> FindAllUsers()
        {
            try
            {
                var users = await _userRepository.FindAllUsersAsync();
                if (!users.Any())
                {
                    return NotFound("Nenhum usuário encontrado."); // Retorna 404 se a lista estiver vazia
                }

                var userListDTOs = ConvertToUserListDTOs(users);
                return Ok(userListDTOs); // Retorna 200 OK com a lista de usuários
            }
            catch (Exception ex)
            {
                // Tratamento de erro adequado
                return StatusCode(500, "Ocorreu um erro interno."); // Retorna 500 em caso de erro interno
            }
        }

        // Método para retornar todos os usuários com um status específico
        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<UserListDTO>>> FindAllUsersByStatus(StatusUser status)
        {
            try
            {
                var users = await _userRepository.FindAllUsersByStatusAsync(status);
                if (!users.Any())
                {
                    return NotFound($"Nenhum usuário encontrado com o status {status}.");
                }

                var userListDTOs = ConvertToUserListDTOs(users);
                return Ok(userListDTOs);
            }
            catch (Exception ex)
            {
                // Tratamento de erro adequado
                return StatusCode(500, "Ocorreu um erro interno ao buscar usuários por status.");
            }
        }

        //Método para criar um User
        [HttpPost]
        public async Task<ActionResult<UserModel>> RegisterUser(UserModel userModel)
        {
            try
            {
                var newUser = await _userRepository.RegisterUserAsync(userModel);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                // Tratamento de erro adequado
                return StatusCode(500, ex.Message);
            }
        }

        // Método para atualizar informações de um usuário existente
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, UserUpdateDTO updatedUserDTO)
        {
            try
            {
                var updatedUser = new UserModel
                {
                    Password = updatedUserDTO.Password,
                    Status = updatedUserDTO.Status
                };

                var updatedUserData = await _userRepository.UpdateUserAsync(id, updatedUser);

                return Ok(updatedUserData); // Retorna o usuário atualizado
            }
            catch (Exception ex)
            {
                // Tratamento de erro adequado
                return StatusCode(500, ex.Message);
            }
        }

        private List<UserListDTO> ConvertToUserListDTOs(IEnumerable<UserModel> users)
        {
            return users.Select(u => new UserListDTO
            {
                Id = u.Id,
                Login = u.Login,
                Status = u.Status
            }).ToList();
        }
    }
}
