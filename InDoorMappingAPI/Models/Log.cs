using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndoorMappingAPI.Models
{
    [Table("logs", Schema = "public")]
    public class Log
    {
        [Key]
        [Column("logid")]
        public long LogId { get; set; }

        [Column("usuarioid")]
        public long? UsuarioId { get; set; }

        [Required]
        [Column("acao")]
        public string Acao { get; set; }

        [Column("datahora")]
        public DateTime? DataHora { get; set; }

        public Usuario Usuario { get; set; }
    }
}
