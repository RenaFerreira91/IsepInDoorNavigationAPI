using System;

namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetDiarioDto
    {
        public int DiarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string Tipo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }
    }
}
