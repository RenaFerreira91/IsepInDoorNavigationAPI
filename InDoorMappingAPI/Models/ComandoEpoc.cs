using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("comandosEpoc", Schema = "public")]
    public class ComandoEpoc
    {
        [Key]
        [Column("comandoid")]
        public int ComandoId { get; set; }

        [Required]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        [Column("comando")]
        public string Comando { get; set; }

        [Required]
        [Column("intensidade")]
        public double Intensidade { get; set; }

        [Required]
        [Column("datahora")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }

}
