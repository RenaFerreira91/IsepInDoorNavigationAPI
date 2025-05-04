using InDoorMappingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("caminhos_2", Schema = "public")]
    public class Caminho2
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("origemid")]
        public long OrigemId { get; set; }
        [ForeignKey("OrigemId")]
        public Infraestrutura Origem { get; set; }

        [Required]
        [Column("destinoid")]
        public long DestinoId { get; set; }
        [ForeignKey("DestinoId")]
        public Infraestrutura Destino { get; set; }

        [Required]
        [Column("acessivel")]
        public bool Acessivel { get; set; }

        [Required]
        [Column("piso")]
        public bool Piso { get; set; }

        [Column("lista_coordenadas")]
        public string ListaCoordenadas { get; set; }  // string (WKT, GeoJSON)


    }
}
