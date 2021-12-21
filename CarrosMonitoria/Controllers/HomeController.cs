using CarrosMonitoria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarrosMonitoria.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context contexto)
        {
            _context = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carros()
        {
            var carros = _context.cadastrarCarros.ToList();
            return View(carros);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult Compras()
        {
            return View();
        }
        public IActionResult CadastroCarro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCarro(CadastrarCarro carro)
        {
            _context.cadastrarCarros.Add(carro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CadastrarPromocao()
        {
            return View();
        }

        public IActionResult Comprar()
        {
            return View();
        }

        // GET: Contatoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Contato,Email,Mensagem")] Contato contato)
        {

            _context.Add(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditarCarro(int id)
        {
            var carro = _context.cadastrarCarros.Find(id);
            if (carro == null)
            {
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        [HttpPost]
        public IActionResult EditarCarro(CadastrarCarro carro)
        {
            _context.cadastrarCarros.Update(carro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}