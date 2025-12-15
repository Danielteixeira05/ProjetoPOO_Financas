using System.ComponentModel.DataAnnotations;

namespace GestaoFinancasWeb.Models
{
    public class Utilizador
    {
        // Requisito: Identificação
        public int Id { get; set; } 

        [Required(ErrorMessage = "O Username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A Password é obrigatória")]
        public string Password { get; set; }

        // Requisito: Nome
        [Required(ErrorMessage = "O Nome Completo é obrigatório")]
        public string NomeCompleto { get; set; }

        // Requisito: Email
        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        public string Email { get; set; }

        // Requisito: Perfil como: "Normal"
        public string Perfil { get; set; } = "Normal"; 
    }
}