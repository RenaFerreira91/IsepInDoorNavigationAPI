﻿namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetInfraestruturaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Piso { get; set; }
        public bool Acessivel { get; set; }
        public string TipoInfraestrutura { get; set; }
    }

}
