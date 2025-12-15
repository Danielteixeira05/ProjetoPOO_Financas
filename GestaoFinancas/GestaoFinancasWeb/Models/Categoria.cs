using System.ComponentModel.DataAnnotations;

namespace GestaoFinancasWeb.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    public string Nome { get; set; }
}