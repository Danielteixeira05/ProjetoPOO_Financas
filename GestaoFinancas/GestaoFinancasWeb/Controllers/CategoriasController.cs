using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Http; 

namespace GestaoFinancasWeb.Controllers;

public class CategoriasController : Controller
{
    // GET: Listar Categorias
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Utilizador") == null) return RedirectToAction("Login", "Conta");
        var lista = Persistencia.CarregarCategorias();
        return View(lista);
    }

    // GET: Criar
    public IActionResult Criar()
    {
        if (HttpContext.Session.GetString("Utilizador") == null) return RedirectToAction("Login", "Conta");
        return View();
    }

    // POST: Criar
    [HttpPost]
    public IActionResult Criar(Categoria novaCat)
    {
        if (ModelState.IsValid)
        {
            var lista = Persistencia.CarregarCategorias();
            // Gera ID automático
            novaCat.Id = lista.Count > 0 ? lista.Max(c => c.Id) + 1 : 1;
            
            lista.Add(novaCat);
            Persistencia.GuardarCategorias(lista);
            return RedirectToAction("Index");
        }
        return View(novaCat);
    }

    // NOVO: ELIMINAR (Pergunta) ---
    public IActionResult Eliminar(int id)
    {
        if (HttpContext.Session.GetString("Utilizador") == null) return RedirectToAction("Login", "Conta");

        var lista = Persistencia.CarregarCategorias();
        var cat = lista.FirstOrDefault(c => c.Id == id);
        
        if (cat == null) return NotFound();
        
        return View(cat);
    }

    // ELIMINAR (Confirmação) ---
    [HttpPost, ActionName("Eliminar")]
    public IActionResult ConfirmarEliminar(int id)
    {
        var lista = Persistencia.CarregarCategorias();
        var cat = lista.FirstOrDefault(c => c.Id == id);

        if (cat != null)
        {
            lista.Remove(cat);
            Persistencia.GuardarCategorias(lista);
        }
        return RedirectToAction("Index");
    }
}