using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace GestaoFinancasWeb.Models
{
    public static class Persistencia
    {
        private static string CaminhoReceitas = "receitas.json";
        private static string CaminhoDespesas = "despesas.json";
        private static string CaminhoUtilizadores = "utilizadores.json";
        private static string CaminhoCategorias = "categorias.json"; // <--- NOVO

        // RECEITAS
        public static void GuardarReceitas(List<Receita> lista)
        {
            string textoJson = JsonSerializer.Serialize(lista);
            File.WriteAllText(CaminhoReceitas, textoJson);
        }

        public static List<Receita> CarregarReceitas()
        {
            if (!File.Exists(CaminhoReceitas)) return new List<Receita>();
            string textoJson = File.ReadAllText(CaminhoReceitas);
            return JsonSerializer.Deserialize<List<Receita>>(textoJson) ?? new List<Receita>();
        }

        // DESPESAS 
        public static void GuardarDespesas(List<Despesa> lista)
        {
            string textoJson = JsonSerializer.Serialize(lista);
            File.WriteAllText(CaminhoDespesas, textoJson);
        }

        public static List<Despesa> CarregarDespesas()
        {
            if (!File.Exists(CaminhoDespesas)) return new List<Despesa>();
            string textoJson = File.ReadAllText(CaminhoDespesas);
            return JsonSerializer.Deserialize<List<Despesa>>(textoJson) ?? new List<Despesa>();
        }

        // UTILIZADORES 
        public static void GuardarUtilizadores(List<Utilizador> lista)
        {
            string textoJson = JsonSerializer.Serialize(lista);
            File.WriteAllText(CaminhoUtilizadores, textoJson);
        }

        public static List<Utilizador> CarregarUtilizadores()
        {
            if (!File.Exists(CaminhoUtilizadores)) return new List<Utilizador>();
            string textoJson = File.ReadAllText(CaminhoUtilizadores);
            return JsonSerializer.Deserialize<List<Utilizador>>(textoJson) ?? new List<Utilizador>();
        }

        // CATEGORIAS 
        public static void GuardarCategorias(List<Categoria> lista)
        {
            string textoJson = JsonSerializer.Serialize(lista);
            File.WriteAllText(CaminhoCategorias, textoJson);
        }

        public static List<Categoria> CarregarCategorias()
        {
            if (!File.Exists(CaminhoCategorias)) 
            {
                // Se o ficheiro não existe, basicamente pode-se criar categorias padrão para não ficar vazio
                var padrao = new List<Categoria> 
                { 
                    new Categoria { Id = 1, Nome = "Alimentação" },
                    new Categoria { Id = 2, Nome = "Transporte" },
                    new Categoria { Id = 3, Nome = "Lazer" },
                    new Categoria { Id = 4, Nome = "Saúde" },
                    new Categoria { Id = 5, Nome = "Salário" },
                    new Categoria { Id = 6, Nome = "Outros" }
                };
                GuardarCategorias(padrao);
                return padrao;
            }
            string textoJson = File.ReadAllText(CaminhoCategorias);
            return JsonSerializer.Deserialize<List<Categoria>>(textoJson) ?? new List<Categoria>();
        }
    }
}