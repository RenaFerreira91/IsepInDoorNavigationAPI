using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoorMappingAPI.Models
{
    [Table("diario", Schema = "public")]
    public class Diario
    {
        [Key]
        [Column("diarioid")]
        public int DiarioId { get; set; }

        [Required]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; } // Ex: "texto", "imagem", etc.

        [Required]
        [Column("conteudo")]
        public string Conteudo { get; set; }

        [Required]
        [Column("datahora")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
