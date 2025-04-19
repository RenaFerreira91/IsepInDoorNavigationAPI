using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoorMappingAPI.Models
{
    [Table("feedbackcaminhos", Schema = "public")]
    public class FeedbackCaminho
    {
        [Key]
        [Column("feedbackid")]
        public int FeedbackId { get; set; }

        [Required]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        [Column("caminhoid")]
        public long CaminhoId { get; set; }

        [ForeignKey("CaminhoId")]
        public Caminho Caminho { get; set; }

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
