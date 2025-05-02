using InDoorMappingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetCaminhoDTO
    {
        public long Id { get; set; }
        public long OrigemId { get; set; }
        public long DestinoId { get; set; }
        public double Distancia { get; set; }
        public bool Acessivel { get; set; }
        public string? TipoAcessibilidade { get; set; }
    }

}

