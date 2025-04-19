using InDoorMappingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("caminhos", Schema = "public")]
public class Caminho
{
    [Key]
    [Column("id")]
    public long CaminhoId { get; set; }

    [Column("origemid")]
    public int OrigemId { get; set; }

    [Column("destinoid")]
    public int DestinoId { get; set; }

    [Column("distancia")]
    public double Distancia { get; set; }

    [Column("acessivel")]
    public bool Acessivel { get; set; }

    [Column("acessibilidadeid")]
    public long? AcessibilidadeId { get; set; }

    [ForeignKey("OrigemId")]
    public Infraestrutura Origem { get; set; }

    [ForeignKey("DestinoId")]
    public Infraestrutura Destino { get; set; }

    public Acessibilidade Acessibilidade { get; set; }
}
