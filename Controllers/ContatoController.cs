using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Context;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AppContatoDbContext _context;
        public ContatoController(AppContatoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //Lista todos os meus contatos que estão no banco.
        public async Task<IActionResult> Index()
        {
            var contatos = await _context.Contatos.ToListAsync();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]        
        public async Task<IActionResult> Criar(Contato contato)
        {
            if(ModelState.IsValid)
            {
                await _context.Contatos.AddAsync(contato);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if(contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }
        
        [HttpPost]
        public async Task<IActionResult> Editar(Contato model)
        {
            var contato = await _context.Contatos.FindAsync(model.Id);

            contato.Nome = model.Nome;
            contato.Telefone = model.Telefone;
            contato.Ativo = model.Ativo;

            _context.Contatos.Update(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}