using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using Microsoft.AspNetCore.Http; 

namespace GestaoFinancasWeb.Controllers
{
    public class ReceitasController : Controller
    {
        private static List<Receita> listaReceitas = Persistencia.CarregarReceitas();

        // LISTAR
        public IActionResult Index()
        {
            // Segurança: Se não houver login, manda para fora
            if (HttpContext.Session.GetString("Utilizador") == null)
            {
                return RedirectToAction("Login", "Conta");
            }

            listaReceitas = Persistencia.CarregarReceitas();
            return View(listaReceitas);
        }

        // CRIAR (Formulário)
        public IActionResult Criar()
        {
            // --- MUDANÇA AQUI ---
            // Envia a lista de categorias para o Dropdown funcionar
            ViewBag.ListaCategorias = Persistencia.CarregarCategorias(); 
            return View();
        }

        // CRIAR (Guardar)
        [HttpPost]
        public IActionResult Criar(Receita novaReceita)
        {
            if (ModelState.IsValid)
            {
                novaReceita.Identificacao = listaReceitas.Count > 0 ? listaReceitas.Max(r => r.Identificacao) + 1 : 1;
                listaReceitas.Add(novaReceita);
                Persistencia.GuardarReceitas(listaReceitas); 
                return RedirectToAction("Index");
            }
            
            // --- MUDANÇA AQUI ---
            // Se der erro, recarrega a lista para o Dropdown não desaparecer
            ViewBag.ListaCategorias = Persistencia.CarregarCategorias();
            return View(novaReceita);
        }

        // ELIMINAR (Pergunta)
        public IActionResult Eliminar(int id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Identificacao == id);
            if (receita == null) return NotFound();
            return View(receita);
        }

        // ELIMINAR (Confirmar)
        [HttpPost, ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Identificacao == id);
            if (receita != null)
            {
                listaReceitas.Remove(receita);
                Persistencia.GuardarReceitas(listaReceitas); 
            }
            return RedirectToAction("Index");
        }

        // EDITAR (Formulário)
        public IActionResult Editar(int id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Identificacao == id);
            if (receita == null) return NotFound();

            // --- MUDANÇA AQUI ---
            // No editar também precisamos do Dropdown
            ViewBag.ListaCategorias = Persistencia.CarregarCategorias();

            return View(receita);
        }

        // EDITAR (Guardar)
        [HttpPost]
        public IActionResult Editar(Receita receitaAtualizada)
        {
            var receitaAntiga = listaReceitas.FirstOrDefault(r => r.Identificacao == receitaAtualizada.Identificacao);
            if (receitaAntiga != null)
            {
                receitaAntiga.Descricao = receitaAtualizada.Descricao;
                receitaAntiga.Valor = receitaAtualizada.Valor;
                receitaAntiga.CategoriaNome = receitaAtualizada.CategoriaNome;
                receitaAntiga.Data = receitaAtualizada.Data;
                
                Persistencia.GuardarReceitas(listaReceitas); 
                return RedirectToAction("Index");
            }

            // Se der erro, recarrega a lista
            ViewBag.ListaCategorias = Persistencia.CarregarCategorias();
            return View(receitaAtualizada);
        }
    }
}