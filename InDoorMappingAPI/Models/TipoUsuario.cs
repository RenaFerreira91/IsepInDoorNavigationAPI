﻿using InDoorMappingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("tiposusuarios", Schema = "public")]
public class TipoUsuario
{
    [Key]
    [Column("id")]
    public int TipoUsuarioId { get; set; }

    [Required]
    [Column("tipo")]
    public string Tipo { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }
}