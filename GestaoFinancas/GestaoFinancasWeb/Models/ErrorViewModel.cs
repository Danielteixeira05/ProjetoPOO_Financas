namespace GestaoFinancasWeb.Models;
//aqui definimos o erro
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
