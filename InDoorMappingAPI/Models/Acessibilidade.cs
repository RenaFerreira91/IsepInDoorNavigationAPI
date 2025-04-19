using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{

    [Table("acessibilidade", Schema = "public")]
    public class Acessibilidade
    {
        [Key]
        [Column("acessibilidadeid")]
        public long AcessibilidadeId { get; set; }

        [Required]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        public ICollection<Caminho> Caminhos { get; set; }
    }
}
