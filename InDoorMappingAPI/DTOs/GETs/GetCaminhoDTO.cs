using InDoorMappingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetCaminhoDTO
    {
    
        public long CaminhoId { get; set; }

        public int OrigemId { get; set; }

        public int DestinoId { get; set; }

        public double Distancia { get; set; }

        public bool Acessivel { get; set; }

        public int? AcessibilidadeId { get; set; }

    }
}

