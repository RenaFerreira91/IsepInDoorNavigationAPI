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
        [Column("id")]
        public int Id { get; set; }

        [Column("tipoinfraestruturaid")]
        public int TipoInfraestruturaId { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        [Column("piso")]
        public int Piso { get; set; }

        [Column("acessivel")]
        public bool Acessivel { get; set; }

        // Relações
        [ForeignKey("TipoInfraestruturaId")]
        public TipoInfraestrutura TipoInfraestrutura { get; set; }

        public ICollection<Caminho> CaminhosOrigem { get; set; }
        public ICollection<Caminho> CaminhosDestino { get; set; }
    }
}
