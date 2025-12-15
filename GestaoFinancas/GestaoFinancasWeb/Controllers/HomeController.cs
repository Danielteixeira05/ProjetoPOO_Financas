using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using System.Linq; // Importante para a soma (.Sum)

namespace GestaoFinancasWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // 1. Carregar as listas
        var receitas = Persistencia.CarregarReceitas();
        var despesas = Persistencia.CarregarDespesas();

        // 2. Preparar os dados para o ecrã
        var dados = new Dashboard();
        
        // Fazer as somas
        dados.TotalReceitas = receitas.Sum(r => r.Valor);
        dados.TotalDespesas = despesas.Sum(d => d.Valor);
        
        // Calcular o saldo (Receita - Despesa)
        dados.Saldo = dados.TotalReceitas - dados.TotalDespesas;
        
        dados.QuantidadeTransacoes = receitas.Count + despesas.Count;

        // 3. Enviar para a View
        return View(dados);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}