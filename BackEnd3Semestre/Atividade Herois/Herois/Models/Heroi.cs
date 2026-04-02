using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Herois.Models;

[Table("Heroi")]
public partial class Heroi
{
    [Key]
    public Guid IdHeroi { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Poder { get; set; } = null!;

    public int Idade { get; set; }

    public Guid? IdEquipe { get; set; }

    [ForeignKey("IdEquipe")]
    [InverseProperty("Herois")]
    public virtual Equipe? IdEquipeNavigation { get; set; }

    [InverseProperty("IdHeroiNavigation")]
    public virtual ICollection<Missao> Missaos { get; set; } = new List<Missao>();
}
