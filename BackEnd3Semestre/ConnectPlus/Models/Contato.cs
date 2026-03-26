using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
[Index("FormaDeContato", Name = "UQ__Contato__43F549434C23C60F", IsUnique = true)]
public partial class Contato
{
    [Key]
    public Guid IdContato { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string FormaDeContato { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    public Guid? IdTipoContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("Contatos")]
    public virtual TipoContato? IdTipoContatoNavigation { get; set; }
}
