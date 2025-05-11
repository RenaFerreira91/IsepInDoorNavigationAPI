using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InDoorMappingAPI.Data;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs.InDoorMappingAPI.DTOs.PUTs;
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

        public async Task<List<GetCaminhoDTO>> GetCaminho(int origemId, int destinoId, bool apenasAcessiveis = false)
        {
            var caminhos = await _repo.GetCaminhoBidirectional(origemId, destinoId);

            if (apenasAcessiveis)
                caminhos = caminhos.Where(c => c.Acessivel).ToList();

            return _mapper.Map<List<GetCaminhoDTO>>(caminhos);
        }

        public async Task<GetMelhorCaminhoDTO> ObterMelhorCaminhoAsync(long destinoId, List<long> infraestruturasBloqueadas)
        {
            var caminhos = await _repo.GetAllAsync();


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
        public async Task<List<GetCaminhoDTO>> GetAllAsync()
        {
            var caminhos = await _repo.GetAllAsync();
            return _mapper.Map<List<GetCaminhoDTO>>(caminhos);
        }

        public async Task<GetCaminhoDTO> GetByIdAsync(long id)
        {
            var caminho = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetCaminhoDTO>(caminho);
        }

        public async Task AddAsync(PostCaminhoDTO dto)
        {
            var caminho = _mapper.Map<Caminho>(dto);
            await _repo.AddAsync(caminho);
        }

        public async Task UpdateAsync(PutCaminhoDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) throw new InvalidOperationException("Caminho não encontrado.");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new InvalidOperationException("Caminho não encontrado.");

            await _repo.DeleteAsync(id);
        }

        public async Task<List<GetCaminhoDetalhadoDTO>> GetAllWithDetailsAsync()
        {
            var caminhos = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<List<GetCaminhoDetalhadoDTO>>(caminhos);
        }
        public async Task<GetCaminhosDetalhadoDTO> GetAllPossiblePathsAsync(long origemId, long destinoId)
        {
            var caminhosDb = await _repo.GetAllWithDetailsAsync();
            caminhosDb = caminhosDb.Where(c => c.Acessivel).ToList();
            var caminhosDetalhados = _mapper.Map<List<GetCaminhoDetalhadoDTO>>(caminhosDb);

            // monta grafo como dicionário: origemId -> lista de caminhos (detalhados)
            var grafo = new Dictionary<long, List<GetCaminhoDetalhadoDTO>>();

            foreach (var c in caminhosDetalhados)
            {
                var forward = new GetCaminhoDetalhadoDTO
                {
                    Id = c.Id,
                    OrigemId = c.OrigemId,
                    OrigemDescricao = c.OrigemDescricao,
                    OrigemPiso = c.OrigemPiso,
                    OrigemTipoInfraestrutura = c.OrigemTipoInfraestrutura,
                    DestinoId = c.DestinoId,
                    DestinoDescricao = c.DestinoDescricao,
                    DestinoPiso = c.DestinoPiso,
                    DestinoTipoInfraestrutura = c.DestinoTipoInfraestrutura,
                    Distancia = c.Distancia,
                    Acessivel = c.Acessivel,
                    TipoAcessibilidade = c.TipoAcessibilidade
                };

                var backward = new GetCaminhoDetalhadoDTO
                {
                    Id = c.Id,
                    OrigemId = c.DestinoId,
                    OrigemDescricao = c.DestinoDescricao,
                    OrigemPiso = c.DestinoPiso,
                    OrigemTipoInfraestrutura = c.DestinoTipoInfraestrutura,
                    DestinoId = c.OrigemId,
                    DestinoDescricao = c.OrigemDescricao,
                    DestinoPiso = c.OrigemPiso,
                    DestinoTipoInfraestrutura = c.OrigemTipoInfraestrutura,
                    Distancia = c.Distancia,
                    Acessivel = c.Acessivel,
                    TipoAcessibilidade = c.TipoAcessibilidade
                };

                if (!grafo.ContainsKey(c.OrigemId))
                    grafo[c.OrigemId] = new();
                if (!grafo.ContainsKey(c.DestinoId))
                    grafo[c.DestinoId] = new();

                grafo[c.OrigemId].Add(forward);
                grafo[c.DestinoId].Add(backward);
            }

            var caminhos = new List<List<GetCaminhoDetalhadoDTO>>();
            var fila = new Queue<(long atual, List<GetCaminhoDetalhadoDTO> percurso)>();
            fila.Enqueue((origemId, new List<GetCaminhoDetalhadoDTO>()));

            int maxCaminhos = 10000; // máximo de caminhos a devolver
            int maxProfundidade = 15; // limite de passos por caminho

            while (fila.Count > 0)
            {
                var (atual, percurso) = fila.Dequeue();

                if (atual == destinoId)
                {
                    caminhos.Add(percurso);

                    if (caminhos.Count >= maxCaminhos)
                        break;

                    continue;
                }

                if (!grafo.ContainsKey(atual)) continue;

                foreach (var segmento in grafo[atual])
                {
                    // Evita ciclos: não volta a nós já percorridos
                    var nosVisitados = percurso
                        .Select(p => p.OrigemId)
                        .Append(percurso.LastOrDefault()?.DestinoId ?? atual)
                        .ToHashSet();

                    if (nosVisitados.Contains(segmento.DestinoId))
                        continue;

                    // Limita profundidade
                    if (percurso.Count >= maxProfundidade)
                        continue;

                    var novoPercurso = new List<GetCaminhoDetalhadoDTO>(percurso) { segmento };
                    fila.Enqueue((segmento.DestinoId, novoPercurso));
                }
            }
            var caminhosUnicos = caminhos
                .GroupBy(percurso =>
                    string.Join("->", percurso.Select(p => $"{p.OrigemId}-{p.DestinoId}"))
                )
                .Select(g => g.First())
                .ToList();
            return new GetCaminhosDetalhadoDTO
            {
                OrigemId = origemId,
                DestinoId = destinoId,
                Caminhos = caminhosUnicos
            };
        }


        
    }

}
