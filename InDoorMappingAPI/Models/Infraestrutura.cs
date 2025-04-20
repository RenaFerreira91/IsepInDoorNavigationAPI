using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Models
{
    [Table("infraestruturas", Schema = "public")]
    public class Infraestrutura
    {

        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("TipoInfraestrutura")]
        public long TipoInfraestruturaId { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public int Piso { get; set; }

        [Required]
        public bool Acessivel { get; set; } = true;

        public virtual TipoInfraestrutura TipoInfraestrutura { get; set; }
    }
}
