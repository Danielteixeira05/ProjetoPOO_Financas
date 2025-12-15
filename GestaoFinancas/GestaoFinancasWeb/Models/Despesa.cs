namespace GestaoFinancasWeb.Models;

public class Despesa : Transacao
{
    // Construtor que define automaticamente o tipo
    public Despesa()
    {
        // Se a classe Transacao tiver a propriedade Tipo, podes descomentar isto:
        // Tipo = "Despesa"; 
    }
}