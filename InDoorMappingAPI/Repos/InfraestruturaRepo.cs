﻿using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class InfraestruturaRepo : IInfraestruturaRepo
    {
        private readonly DataContext _context;
        public InfraestruturaRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Infraestrutura>> GetAllAsync()
        {
            return await _context.Infraestruturas
                .Include(i => i.TipoInfraestrutura)
                .ToListAsync();
        }

        public async Task<Infraestrutura> GetByIdAsync(int id)
        {
            return await _context.Infraestruturas
                .Include(i => i.TipoInfraestrutura)
                .FirstOrDefaultAsync(i => i.InfraestruturaId == id);
        }

        public async Task AddAsync(Infraestrutura entity)
        {
            await _context.Infraestruturas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
