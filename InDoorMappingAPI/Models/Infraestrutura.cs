using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{
    [Table("infraestruturas", Schema = "public")]
    public class Infraestrutura
    {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("tipoinfraestruturaid")]
        public long TipoInfraestruturaId { get; set; }

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
        public int Piso { get; set; }

        [Required]
        [Column("acessivel")]
        public bool Acessivel { get; set; } = true;


        public virtual TipoInfraestrutura TipoInfraestrutura { get; set; }
    }
}
