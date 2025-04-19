using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("usuarios", Schema = "public")]
    public class Usuario
    {
        [Key]
        [Column("usuarioid")]
        public long UsuarioId { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [ForeignKey("TipoUsuario")]
        [Column("tipousuarioid")]
        public int TipoUsuarioId { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        [Column("mobilidadeid")]
        public int MobilidadeId { get; set; }

        [ForeignKey("MobilidadeId")]
        public Mobilidade Mobilidade { get; set; }
        
        [Required]
        [Column("passwordhash")]
        public string PasswordHash { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}