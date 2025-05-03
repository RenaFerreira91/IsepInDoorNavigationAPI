using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{

    [Table("recoverytokens", Schema = "public")]
    public class RecoveryToken
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("userid")]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }

        [Required]
        [Column("token")]
        public string Token { get; set; }

        [Column("expiration")]
        public DateTime Expiration { get; set; }
    }
}
