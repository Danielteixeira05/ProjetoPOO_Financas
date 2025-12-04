namespace GestaoFinancasWeb.Models;

public class Receita
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public string Categoria { get; set; }
    // Construtor vazio
    public Receita() { }
}