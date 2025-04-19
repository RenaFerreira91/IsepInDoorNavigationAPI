using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoorMappingAPI.Models
{
    [Table("tiposinfraestrutura", Schema = "public")]
    public class TipoInfraestrutura
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }

        public ICollection<Infraestrutura> Infraestruturas { get; set; }
    }
}
