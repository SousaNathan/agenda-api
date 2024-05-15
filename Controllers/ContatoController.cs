using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_api.Context;
using agenda_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato) 
        {
            _context.Add(contato);
            _context.SaveChanges();

            // return Ok(contato) Retorna o contato que foi creado;

            // Outro forma de retorno
            // Informa a rota a ser usada para obter o registro que acabou de ser criado.
            return 
                CreatedAtAction
                (
                    nameof(ObterPorId),
                    new { id = contato.Id },
                    contato
                );
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) 
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();
           
            return Ok(contato);
        }

        [HttpGet("{nome}")]
        public IActionResult ObterPorNome(string nome) 
        {
            var contatos = _context.Contatos
                .Where(c => c.Nome.Contains(nome))
                .ToList();

            if (!contatos.Any())
                return NotFound();
           
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarContato(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarContato(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent(); // resposta de cucesso sem conteudo pois foi deletado;
        }
    }
}