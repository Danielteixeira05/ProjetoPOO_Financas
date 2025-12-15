using System.ComponentModel.DataAnnotations;

namespace GestaoFinancasWeb.Models;

public class Transacao
{
    // Nota: Nas Despesas usámos "Identificacao", nas Receitas usámos "Id".
    // Para funcionar com o código da Despesa que te dei, vamos usar Identificacao aqui.
    public int Identificacao { get; set; }

    public string Descricao { get; set; }
    
    public double Valor { get; set; }
    
    // Na Despesa chamámos "CategoriaNome", na Receita era só "Categoria".
    // Vamos usar CategoriaNome para bater certo com a Despesa.
    public string CategoriaNome { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }
}