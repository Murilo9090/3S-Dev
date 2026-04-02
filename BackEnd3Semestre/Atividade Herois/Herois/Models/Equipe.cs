using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Herois.Models;

[Table("Equipe")]
public partial class Equipe
{
    [Key]
    public Guid IdEquipe { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [InverseProperty("IdEquipeNavigation")]
    public virtual ICollection<Heroi> Herois { get; set; } = new List<Heroi>();

    [InverseProperty("IdEquipeNavigation")]
    public virtual ICollection<Missao> Missaos { get; set; } = new List<Missao>();
}
