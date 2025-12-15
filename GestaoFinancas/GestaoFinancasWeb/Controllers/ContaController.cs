using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Http; // Para a Sessão

namespace GestaoFinancasWeb.Controllers;

public class ContaController : Controller
{
    // GET: Login (Mostra o formulário)
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login (Verifica a password)
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var utilizadores = Persistencia.CarregarUtilizadores();
        
        // Procura se existe alguém com este nome e password
        var user = utilizadores.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            // SUCESSO: Cria a sessão (o "bilhete de entrada")
            HttpContext.Session.SetString("Utilizador", user.Username);
            return RedirectToAction("Index", "Home"); // Vai para o Dashboard
        }

        // ERRO:
        ViewBag.Erro = "Nome ou Password incorretos!";
        return View();
    }

    // GET: Registar
    public IActionResult Registar()
    {
        return View();
    }

    // POST: Registar (Grava no ficheiro)
    [HttpPost]
    public IActionResult Registar(Utilizador novoUser)
    {
        var utilizadores = Persistencia.CarregarUtilizadores();

        // Verifica se já existe
        if (utilizadores.Any(u => u.Username == novoUser.Username))
        {
            ViewBag.Erro = "Esse utilizador já existe!";
            return View();
        }

        // Grava
        utilizadores.Add(novoUser);
        Persistencia.GuardarUtilizadores(utilizadores);

        return RedirectToAction("Login");
    }

    // Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); // Rasga o bilhete
        return RedirectToAction("Login");
    }
}