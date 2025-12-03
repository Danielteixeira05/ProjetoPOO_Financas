using System;

public class Utilizador
{
    // Atributos (Dados)
    public int Identificacao { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Perfil { get; set; } // "Admin" ou "Normal"

    // Construtor (Para criar um novo utilizador)
    public Utilizador()
    {
        // Vazio por enquanto
    }

    // Métodos (Ações - Esqueleto)
    public void Registar()
    {
        Console.WriteLine("A registar utilizador... (Por implementar)");
    }

    public bool Login(string email, string password)
    {
        Console.WriteLine("A verificar login... (Por implementar)");
        return true; // Retorna sempre verdade por agora, só para não dar erro
    }
}