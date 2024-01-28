using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema_de_Gestão_de_Colaboradores.Models;
using Sistema_de_Gestão_de_Colaboradores.ModelsDTO.UnitDTO;
using Sistema_de_Gestão_de_Colaboradores.Repositories;
using Sistema_de_Gestão_de_Colaboradores.Repositories.Interface;

namespace Sistema_de_Gestão_de_Colaboradores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;

        private readonly ILogger<UnitController> _logger;

        public UnitController(IUnitRepository _unitRepository, ILogger<UnitController> logger)
        {
            this._unitRepository = _unitRepository;
            _logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult<List<UnitModel>>> UnitWithEmployees()
        {
            try
            {
                var units = await _unitRepository.FindAllUnitsAsync();
                if (units == null || !units.Any())
                {
                    return NotFound("Nenhuma unidade encontrada.");
                }

                return Ok(units);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar unidades com colaboradores.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UnitModel>> RegisteUnit([FromBody] UnitCreatedDTO unitDto)
        {
            try
            {

                var newUnit = await _unitRepository.RegisterUnitAsync(new UnitModel(unitDto.UnitCode, unitDto.Name));
                return Ok(newUnit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}/deactivate")]
        public async Task<IActionResult> DeactivateUnit(int id)
        {
            try
            {
                bool result = await _unitRepository.DeactivyUnitAsync(id);
                if (!result)
                {
                    return NotFound($"Unit with ID {id} not found.");
                }
                return NoContent(); // Retorna um status 204, indicando que a operação foi bem-sucedida mas não tem um corpo de resposta.
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/activate")]
        public async Task<IActionResult> ActivateUnit(int id)
        {
            try
            {
                bool result = await _unitRepository.ActivateUnitAsync(id);
                if (!result)
                {
                    return NotFound($"Unit with ID {id} not found.");
                }

                return NoContent(); // Retorna um status 204, indicando que a operação foi bem-sucedida mas não tem um corpo de resposta.
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
