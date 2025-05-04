using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("localizacoes_usuario", Schema = "public")]
    public class LocalizacaoUsuario
    {
        [Key]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [Required]
        [Column("latitude")]
        public double Latitude { get; set; }

        [Required]
        [Column("longitude")]
        public double Longitude { get; set; }

        [Required]
        [Column("datahora")]
        public DateTime DataHora { get; set; } = DateTime.UtcNow;

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}



