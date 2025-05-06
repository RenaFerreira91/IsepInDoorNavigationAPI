using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{
    [Table("feedbackcaminhos", Schema = "public")]
    public class FeedbackCaminho
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [Required]
        [Column("caminhoid")]
        public long CaminhoId { get; set; }

        [Required]
        [Column("avaliacao")]
        [Range(1, 5)]
        public int Avaliacao { get; set; }

        [Column("comentario")]
        public string? Comentario { get; set; }

        [Required]
        [Column("datahora")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
