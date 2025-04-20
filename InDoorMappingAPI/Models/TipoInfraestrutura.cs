using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{
    [Table("tiposinfraestrutura", Schema = "public")]
    public class TipoInfraestrutura
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tipo { get; set; }

        public virtual ICollection<Infraestrutura> Infraestruturas { get; set; }
    }
}
