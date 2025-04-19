using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using di.repaso.junio.MVVM.Base;
using Microsoft.EntityFrameworkCore;

namespace di.repaso.junio.Backend.Modelo;

[Table("jugadores")]
[Index("NombreEquipo", Name = "Nombre_equipo")]
public partial class Jugadore :PropertyChangedDataError // EDITADO
{
    [Key]
    [Column("codigo")]
    public int Codigo { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "El nombre del jugador es obligatorio.")]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Procedencia { get; set; }

    [StringLength(4)]
    [Required(ErrorMessage = "La altura del jugador es obligatorio.")]
    public string? Altura { get; set; }

    // Importante: range
    [Range(100, 350, ErrorMessage ="El peso debe estar entre 100 y 350.")]
    [Required(ErrorMessage = "El peso del jugador es obligatorio.")]
    public int? Peso { get; set; }

    [Required(ErrorMessage = "La posición del jugador es obligatoria.")]
    [StringLength(5)]
    public string? Posicion { get; set; }

    [Column("Nombre_equipo")]
    [StringLength(20)]
    public string? NombreEquipo { get; set; }

    [InverseProperty("JugadorNavigation")]
    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    [Required(ErrorMessage = "El nombre del equipo es obligatorio.")]
    [ForeignKey("NombreEquipo")]
    [InverseProperty("Jugadores")]
    public virtual Equipo? NombreEquipoNavigation { get; set; }
}
