using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using System.Linq; // Necessário para as contas
using Microsoft.AspNetCore.Http;

namespace GestaoFinancasWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Se não tiver login, mostra zeros ou redireciona 
        // Aqui deixamos mostrar, mas tudo a zero se não houver dados
        
        var receitas = Persistencia.CarregarReceitas();
        var despesas = Persistencia.CarregarDespesas();

        // Calcular Totais Gerais
        double totalRec = receitas.Sum(r => r.Valor);
        double totalDesp = despesas.Sum(d => d.Valor);

        ViewBag.TotalReceitas = totalRec;
        ViewBag.TotalDespesas = totalDesp;
        ViewBag.Saldo = totalRec - totalDesp;

        // RELATÓRIO: Agrupar por Categoria 
        // Calcula quanto se gastou em cada categoria
        ViewBag.DespesasPorCategoria = despesas
            .GroupBy(d => d.CategoriaNome)
            .Select(g => new { Nome = g.Key, Total = g.Sum(d => d.Valor) })
            .ToList();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}