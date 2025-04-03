using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{
    [Table("infraestruturas", Schema = "public")]
    public class Infraestrutura
    {
        [Key]
        [Column("infraestruturaid")]
        public int InfraestruturaId { get; set; }

        [Required]
        [Column("tipoinfraestruturaid")]
        public int TipoInfraestruturaId { get; set; }

        [ForeignKey("TipoInfraestruturaId")]
        public TipoInfraestrutura TipoInfraestrutura { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Required]
        [Column("latitude")]
        public double Latitude { get; set; }

        [Required]
        [Column("longitude")]
        public double Longitude { get; set; }

        [Required]
        [Column("piso")]
        public string Piso { get; set; }

        [Required]
        [Column("acessivel")]
        public bool Acessivel { get; set; }
    }
}
