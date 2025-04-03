using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("caminhos", Schema = "public")]
    public class Caminho
    {
        [Key]
        [Column("caminhoid")]
        public long CaminhoId { get; set; }

        [Column("origembeaconid")]
        public long OrigemBeaconId { get; set; }

        [Column("destinobeaconid")]
        public long DestinoBeaconId { get; set; }

        [Column("distancia")]
        public double Distancia { get; set; }

        [Column("acessivel")]
        public bool Acessivel { get; set; }

        [Column("acessibilidadeid")]
        public long? AcessibilidadeId { get; set; }

        [ForeignKey("OrigemBeaconId")]
        public Beacon Origem { get; set; }

        [ForeignKey("DestinoBeaconId")]
        public Beacon Destino { get; set; }

        public Acessibilidade Acessibilidade { get; set; }
    }
}
