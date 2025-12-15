namespace GestaoFinancasWeb.Models;

//gráfico
public class Dashboard
{
    public double TotalReceitas { get; set; }
    public double TotalDespesas { get; set; }
    public double Saldo { get; set; }
    public int QuantidadeTransacoes { get; set; }
}