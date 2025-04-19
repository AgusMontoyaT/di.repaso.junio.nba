using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using di.repaso.junio.MVVM.Base;
using Microsoft.EntityFrameworkCore;

namespace di.repaso.junio.Backend.Modelo;

[Table("equipos")]
public partial class Equipo : PropertyChangedDataError // editadita
{
    [Key]
    [StringLength(20)]
    // editada:
    [Required(ErrorMessage ="El nombre del equipo es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    public string? Ciudad { get; set; }

    [StringLength(4)]
    [Required(ErrorMessage = "La conferencia del equipo es obligatoria.")]
    public string? Conferencia { get; set; }

    [StringLength(9)]
    [Required(ErrorMessage = "La división del equipo es obligatoria.")]
    public string? Division { get; set; }

    [InverseProperty("NombreEquipoNavigation")]
    public virtual ICollection<Jugadore> Jugadores { get; set; } = new List<Jugadore>();

    [InverseProperty("EquipoLocalNavigation")]
    public virtual ICollection<Partido> PartidoEquipoLocalNavigations { get; set; } = new List<Partido>();

    [InverseProperty("EquipoVisitanteNavigation")]
    public virtual ICollection<Partido> PartidoEquipoVisitanteNavigations { get; set; } = new List<Partido>();
}
