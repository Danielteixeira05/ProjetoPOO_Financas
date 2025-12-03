using System;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }

    // Construtor
    public Categoria(string nome)
    {
        this.Nome = nome;
    }

    // Validação simples
    public bool Validar()
    {
        // Verifica se o nome não está vazio ou só com espaços
        if (string.IsNullOrWhiteSpace(Nome))
        {
            return false;
        }
        return true;
    }
}