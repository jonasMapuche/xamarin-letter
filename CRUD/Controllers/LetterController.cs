using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LetterController : ControllerBase
    {
        public static readonly LetterService _lettersService = new LetterService();
        public static readonly SQLiteServices _sQLiteService = new SQLiteServices();

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons!");
        }

        [HttpGet("content")]
        public async Task<List<Aula>> GetAll()
        {
            return await _lettersService.GetAsync();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(Aula aula)
        {
            await _lettersService.CreateAsync(aula);
            return CreatedAtAction(nameof(Get), new { id = aula.Id }, aula);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aula>> GetContent(string id)
        {
            Aula aula = await _lettersService.GetSentenceSimpleAsync(id);
            if (aula is null)
                return NotFound();
            string fileName = id + ".json";
            Conteudo content = new();
            content = aula.conteudo;
            Arquivo arquivo = new Arquivo
            {
                nome = aula.nome,
                conteudo = content
            };
            using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Arquivo));
                serializer.WriteObject(stream, arquivo);
            }
            return aula;
        }

        [HttpPost("SQLite")]
        public async Task<IActionResult> SQLite()
        {
            List<Aula> aula = await _lettersService.GetAsync();
            await _sQLiteService.CreateAsync(aula);
            return Ok("SQLite build with ten word class.");
        }

    }
}
