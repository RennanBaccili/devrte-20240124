using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.EmployeeDTO;
using Sistema_de_Gestão_de_Colaboradores.Repositories;
using Sistema_de_Gestão_de_Colaboradores.Repositories.Interface;

namespace Sistema_de_Gestão_de_Colaboradores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository _employRepository)
        {
            this._employeeRepository = _employRepository;
        }


        [HttpGet]
        public async Task<IActionResult> FindAllEmployeeAsync()
        {
            try
            {
                var employees = await _employeeRepository.FindAllEmployeeAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EmployeeModel employee)
        {
            if (employee == null)
            {
                return BadRequest("Dados do colaborador são necessários.");
            }

            try
            {
                var registeredEmployee = await _employeeRepository.RegisterEmployeeAsync(employee);
                return Ok(registeredEmployee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log ex para propósitos de debug
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDTO employeeUpdateDTO)
        {
            if (employeeUpdateDTO == null)
            {
                return BadRequest("Os dados de atualização são necessários.");
            }

            try
            {
                var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(id, employeeUpdateDTO);
                return Ok(updatedEmployee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log ex para propósitos de debug
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno ao atualizar as informações do colaborador.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna um status 404 se o colaborador não for encontrado.
            }
            catch (Exception ex)
            {
                // Log ex para propósitos de debug
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno ao tentar excluir o colaborador.");
            }
        }
    }
}
