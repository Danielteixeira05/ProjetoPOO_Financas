using System;

public abstract class Transacao
{
    // Atributos comuns a Receitas e Despesas
    public int Identificacao { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
    public Categoria CategoriaTransacao { get; set; }

    // Construtor vazio
    public Transacao() { }

    // Método abstrato: obriga quem herdar a criar a sua própria validação
    // "virtual" significa que pode ser alterado pelas classes filhas
    public virtual bool ValidarValor()
    {
        if (Valor < 0)
        {
            Console.WriteLine("Erro: O valor não pode ser negativo.");
            return false;
        }
        return true;
    }
}