using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly Tarefas _tarefas;

        public TarefasController(Tarefas tarefas)
        {
            _tarefas = tarefas;
        }
        [Authorize]
        [HttpGet("lstTarefas")]
         public ActionResult lstTarefas()
        {
            try
            {
            var tarefas = _tarefas.lstTarefas();
            return Ok(tarefas);
        }

            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro em sua API {ex.Message}");
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
           try
            {

            var lstResponse = lstTarefas();
            lstResponse.Add(request);
            }

            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro em sua API {ex.Message}");
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
