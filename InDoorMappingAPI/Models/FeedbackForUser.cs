using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{
    [Table("feedbackforuser", Schema = "public")]
    public class FeedbackForUser
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("feedbackid")]
        public long FeedbackId { get; set; }

        [Required]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [Required]
        [Column("adminid")]
        public long AdminId { get; set; }

        [Column("comentario")]
        public string? Comentario { get; set; }

        [Required]
        [Column("datahora")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("AdminId")]
        public Usuario Admin { get; set; }
    }
}
