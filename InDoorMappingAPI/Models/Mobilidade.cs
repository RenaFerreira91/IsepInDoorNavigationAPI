using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndoorMappingAPI.Models
{
    [Table("mobilidade", Schema = "public")]
    public class Mobilidade
    {
        [Key]
        [Column("mobilidadeid")]
        public int MobilidadeId { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
