using BuildYourPc.Data;
using BuildYourPc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BuildYourPc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context; // Injeção direta do DbContext

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            // Busca dados da Entidade
            var produtos = await _context.Produtos.ToListAsync();
            
            // Converte Entidade para ViewModel
            var viewModels = produtos.Select(p => new ProdutoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque
            }).ToList();

            return View(viewModels);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var p = await _context.Produtos.FindAsync(id);
            if (p == null) return NotFound();

            var viewModel = new ProdutoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque
            };
            return View(viewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel viewModel)
        {
            // Validação ocorre no ViewModel (DataAnnotations)
            if (ModelState.IsValid)
            {
                // Mapeia ViewModel para Entidade
                var produto = new Produto
                {
                    Nome = viewModel.Nome,
                    Descricao = viewModel.Descricao,
                    Preco = viewModel.Preco,
                    Estoque = viewModel.Estoque
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var p = await _context.Produtos.FindAsync(id);
            if (p == null) return NotFound();

            var viewModel = new ProdutoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque
            };
            return View(viewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null) return NotFound();

                // Atualiza a entidade com dados do ViewModel
                produto.Nome = viewModel.Nome;
                produto.Descricao = viewModel.Descricao;
                produto.Preco = viewModel.Preco;
                produto.Estoque = viewModel.Estoque;

                _context.Update(produto);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Produtos.FindAsync(id);
            if (p == null) return NotFound();

             var viewModel = new ProdutoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque
            };
            return View(viewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}