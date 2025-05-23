﻿using InDoorMappingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.Models
{
    [Table("caminhos", Schema = "public")]
    public class Caminho
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
        [Column("distancia")]
        public double Distancia { get; set; }

        [Required]
        [Column("acessivel")]
        public bool Acessivel { get; set; }

        [Column("acessibilidadeid")]
        public long? AcessibilidadeId { get; set; }

        [ForeignKey("AcessibilidadeId")]
        public virtual Acessibilidade? Acessibilidade { get; set; }

    } 
}
