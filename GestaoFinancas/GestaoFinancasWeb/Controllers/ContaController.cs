using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Http; 

namespace GestaoFinancasWeb.Controllers
{
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
                // SUCESSO: Cria a sessão
                HttpContext.Session.SetString("Utilizador", user.Username);
                // Opcional: Guardar o ID ou Perfil na sessão se precisares no futuro
                HttpContext.Session.SetString("Perfil", user.Perfil);
                
                return RedirectToAction("Index", "Home"); 
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

            // Verifica se já há username
            if (utilizadores.Any(u => u.Username == novoUser.Username))
            {
                ViewBag.Erro = "Esse utilizador já existe!";
                return View(novoUser);
            }

            // Gera ID Automático ---
            novoUser.Id = utilizadores.Count > 0 ? utilizadores.Max(u => u.Id) + 1 : 1;
            
            // Define Perfil Padrão ---
            novoUser.Perfil = "Normal";

            // Grava
            utilizadores.Add(novoUser);
            Persistencia.GuardarUtilizadores(utilizadores);

            return RedirectToAction("Login");
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login");
        }
    }
}