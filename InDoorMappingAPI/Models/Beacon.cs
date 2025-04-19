using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndoorMappingAPI.Models
{
    [Table("beacons", Schema = "public")]
    public class Beacon
    {
        [Key]
        [Column("beaconid")]
        public long BeaconId { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        [Required]
        [Column("localizacao")]
        public string Localizacao { get; set; }

        public ICollection<Caminho> CaminhosOrigem { get; set; }
        public ICollection<Caminho> CaminhosDestino { get; set; }
    }
}
