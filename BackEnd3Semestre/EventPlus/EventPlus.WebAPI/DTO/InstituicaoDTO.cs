using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class InstituicaoDTO
{

    [Required(ErrorMessage = "O Titulo do tipo de evento e obrigatorio!")]

    public string? NomeFantasia { get; set; }

    public string? Cnpj { get; set; }

    public string? Endereco { get; set; }
}


