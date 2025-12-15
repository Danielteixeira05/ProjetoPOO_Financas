using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GestaoFinancasWeb.Models;
using Microsoft.AspNetCore.Http; // <--- OBRIGATÓRIO PARA A SESSÃO

namespace GestaoFinancasWeb.Controllers
{
    public class DespesasController : Controller
    {
        private static List<Despesa> listaDespesas = Persistencia.CarregarDespesas();

        // LISTAR (Agora Protegido)
        public IActionResult Index()
        {
            // --- O PORTEIRO ---
            // Se não houver login, manda para fora
            if (HttpContext.Session.GetString("Utilizador") == null)
            {
                return RedirectToAction("Login", "Conta");
            }
            // ------------------

            listaDespesas = Persistencia.CarregarDespesas();
            return View(listaDespesas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Despesa novaDespesa)
        {
            if (ModelState.IsValid)
            {
                novaDespesa.Identificacao = listaDespesas.Count > 0 ? listaDespesas.Max(d => d.Identificacao) + 1 : 1;
                listaDespesas.Add(novaDespesa);
                Persistencia.GuardarDespesas(listaDespesas);
                return RedirectToAction("Index");
            }
            return View(novaDespesa);
        }

        public IActionResult Eliminar(int id)
        {
            var despesa = listaDespesas.FirstOrDefault(d => d.Identificacao == id);
            if (despesa == null) return NotFound();
            return View(despesa);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int id)
        {
            var despesa = listaDespesas.FirstOrDefault(d => d.Identificacao == id);
            if (despesa != null)
            {
                listaDespesas.Remove(despesa);
                Persistencia.GuardarDespesas(listaDespesas);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var despesa = listaDespesas.FirstOrDefault(d => d.Identificacao == id);
            if (despesa == null) return NotFound();
            return View(despesa);
        }

        [HttpPost]
        public IActionResult Editar(Despesa despesaAtualizada)
        {
            var despesaAntiga = listaDespesas.FirstOrDefault(d => d.Identificacao == despesaAtualizada.Identificacao);
            if (despesaAntiga != null)
            {
                despesaAntiga.Descricao = despesaAtualizada.Descricao;
                despesaAntiga.Valor = despesaAtualizada.Valor;
                despesaAntiga.CategoriaNome = despesaAtualizada.CategoriaNome;
                despesaAntiga.Data = despesaAtualizada.Data;
                Persistencia.GuardarDespesas(listaDespesas);
                return RedirectToAction("Index");
            }
            return View(despesaAtualizada);
        }
    }
}