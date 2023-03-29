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

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {   
                // Busca a tarefa na lista pelo ID
                var tarefa = _tarefas.Find(t => t.ID_TAREFA == id);

                 // Verifica se a tarefa existe
                if (tarefa == null)
                {
                    return NotFound($"Tarefa com ID {id} não encontrada.");
                }

                 // Remove a tarefa da lista
                _tarefas.Remove(tarefa); // Retorna status 204 - No Content

                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro em sua API {ex.Message}");
            }
        }
    }
}
