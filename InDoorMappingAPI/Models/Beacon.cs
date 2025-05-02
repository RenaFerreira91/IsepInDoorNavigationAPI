using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("beacons", Schema = "public")]
    public class Beacon
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

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
    }
}
