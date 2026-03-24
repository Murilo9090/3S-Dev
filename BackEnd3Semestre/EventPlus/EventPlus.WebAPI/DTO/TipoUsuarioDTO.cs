using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class TipoUsuarioDTO
{

    [Required(ErrorMessage = "O Titulo do tipo de evento e obrigatorio!")]

    public string? Titulo { get; set; }
}

