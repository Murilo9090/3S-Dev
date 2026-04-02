using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Herois.Models;

[Table("Missao")]
public partial class Missao
{
    [Key]
    public Guid IdMissao { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    public Guid? IdEquipe { get; set; }

    public Guid? IdHeroi { get; set; }

    [ForeignKey("IdEquipe")]
    [InverseProperty("Missaos")]
    public virtual Equipe? IdEquipeNavigation { get; set; }

    [ForeignKey("IdHeroi")]
    [InverseProperty("Missaos")]
    public virtual Heroi? IdHeroiNavigation { get; set; }
}
