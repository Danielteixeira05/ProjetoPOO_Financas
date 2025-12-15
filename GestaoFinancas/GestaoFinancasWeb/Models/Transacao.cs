using System.ComponentModel.DataAnnotations;

namespace GestaoFinancasWeb.Models;

public class Transacao
{
    // Nas Despesas uso "Identificacao", nas Receitas uso "Id". para o código não chocar e dar erro, é mais safe assim.
    public int Identificacao { get; set; }

    public string Descricao { get; set; }
    
    public double Valor { get; set; }
    
    // Na Despesa a mesma coisa, "CategoriaNome", na Receita é só "Categoria".
    public string CategoriaNome { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }
}