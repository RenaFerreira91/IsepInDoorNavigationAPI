using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostCaminhoDTO
    {
        public int OrigemId { get; set; }

        public int DestinoId { get; set; }

        public double Distancia { get; set; }

        public bool Acessivel { get; set; }

        public int? AcessibilidadeId { get; set; }
    }

}
