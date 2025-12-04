using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models; // Para ele saber o que é uma Receita

namespace GestaoFinancasWeb.Controllers;

public class ReceitasController : Controller
{
    // Uma lista falsa para guardar as receitas na memória (enquanto o site está ligado)
    private static List<Receita> listaReceitas = new List<Receita>();

    // Ação para mostrar a lista
    public IActionResult Index()
    {
        return View(listaReceitas);
    }

    // Ação para mostrar o formulário de criar
    public IActionResult Criar()
    {
        return View();
    }

    // Ação que recebe os dados quando clicas em "Guardar"
    [HttpPost]
    public IActionResult Criar(Receita novaReceita)
    {
        // Dá um ID e guarda na lista
        novaReceita.Id = listaReceitas.Count + 1;
        listaReceitas.Add(novaReceita);
        
        // Volta para a lista principal
        return RedirectToAction("Index");
    }
}