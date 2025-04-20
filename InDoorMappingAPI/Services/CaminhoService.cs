using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InDoorMappingAPI.Data;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI
{
    public class CaminhoService : ICaminhoService
    {
        private readonly ICaminhoRepo _repo;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CaminhoService(ICaminhoRepo repository, DataContext context, IMapper mapper)
        {
            _repo = repository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCaminhoDTO>> ObterCaminhos(int origemId, int destinoId, bool apenasAcessiveis = false)
        {
            var caminhos = await _repo.ObterCaminhos(origemId, destinoId);

            if (apenasAcessiveis)
                caminhos = caminhos.Where(c => c.Acessivel).ToList();

            return _mapper.Map<List<GetCaminhoDTO>>(caminhos);
        }

        public async Task<GetMelhorCaminhoDTO> ObterMelhorCaminhoAsync(long destinoId, List<long> infraestruturasBloqueadas)
        {
            var caminhos = await _repo.ObterTodosCaminhosAcessiveisAsync();


            var grafo = new Dictionary<long, List<(long destino, double distancia)>>();

            foreach (var c in caminhos)
            {
                if (infraestruturasBloqueadas.Contains(c.OrigemId) || infraestruturasBloqueadas.Contains(c.DestinoId))
                    continue;

                if (!grafo.ContainsKey(c.OrigemId))
                    grafo[c.OrigemId] = new List<(long, double)>();

                if (!grafo.ContainsKey(c.DestinoId))
                    grafo[c.DestinoId] = new List<(long, double)>();

                grafo[c.OrigemId].Add((c.DestinoId, c.Distancia));
                grafo[c.DestinoId].Add((c.OrigemId, c.Distancia));
            }

            var entradas = new List<long> { 1, 13 };

            foreach (var entrada in entradas)
            {
                var caminho = BFSComPeso(grafo, entrada, destinoId);
                if (caminho != null)
                {
                    return new GetMelhorCaminhoDTO
                    {
                        InfraestruturasIds = caminho,
                        UsouEntradaAlternativa = entrada == 13,
                        Mensagem = "Caminho acessível encontrado."
                    };
                }
            }

            return new GetMelhorCaminhoDTO
            {
                InfraestruturasIds = null,
                UsouEntradaAlternativa = false,
                Mensagem = "Sem caminho acessível encontrado com as condições atuais."
            };
        }

        private List<long> BFSComPeso(Dictionary<long, List<(long destino, double distancia)>> grafo, long origem, long destino)
        {
            var fila = new Queue<List<long>>();
            var visitados = new HashSet<long>();
            fila.Enqueue(new List<long> { origem });

            while (fila.Count > 0)
            {
                var caminho = fila.Dequeue();
                var atual = caminho.Last();

                if (atual == destino)
                    return caminho;

                if (!grafo.ContainsKey(atual))
                    continue;

                foreach (var vizinho in grafo[atual])
                {
                    if (!visitados.Contains(vizinho.destino))
                    {
                        var novoCaminho = new List<long>(caminho) { vizinho.destino };
                        fila.Enqueue(novoCaminho);
                        visitados.Add(vizinho.destino);
                    }
                }
            }

            return null;
        }
    }

}
