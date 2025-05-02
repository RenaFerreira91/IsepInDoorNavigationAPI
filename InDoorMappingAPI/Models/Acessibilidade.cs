using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDoorMappingAPI.Models
{

    [Table("acessibilidade", Schema = "public")]
    public class Acessibilidade
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("tipo")]
        public string Tipo { get; set; }

        public virtual ICollection<Caminho> Caminhos { get; set; }
    }
}
