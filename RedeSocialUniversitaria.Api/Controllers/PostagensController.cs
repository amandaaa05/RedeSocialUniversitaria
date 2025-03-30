using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Domain;
using RedeSocialUniversitaria.Infra;

namespace RedeSocialUniversitaria.Api.Controllers
{
    public class PostagensController : Controller
    {
        private readonly SqlContext _context;

        public PostagensController(SqlContext context)
        {
            _context = context;
        }

        // GET: Postagems
        public async Task<IActionResult> Index()
        {
            var sqlContext = _context.Postagens.Include(p => p.Autor);
            return View(await sqlContext.ToListAsync());
        }

        // GET: Postagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagens
                .Include(p => p.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // GET: Postagems/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Curso");
            return View();
        }

        // POST: Postagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,Conteudo,Data,Curtidas")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Curso", postagem.UsuarioId);
            return View(postagem);
        }

        // GET: Postagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagens.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Curso", postagem.UsuarioId);
            return View(postagem);
        }

        // POST: Postagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,Conteudo,Data,Curtidas")] Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemExists(postagem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Curso", postagem.UsuarioId);
            return View(postagem);
        }

        // GET: Postagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagens
                .Include(p => p.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // POST: Postagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagem = await _context.Postagens.FindAsync(id);
            if (postagem != null)
            {
                _context.Postagens.Remove(postagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagemExists(int id)
        {
            return _context.Postagens.Any(e => e.Id == id);
        }
    }
}
