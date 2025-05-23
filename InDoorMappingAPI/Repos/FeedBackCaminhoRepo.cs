﻿using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FeedbackCaminhoRepo : IFeedbackCaminhoRepo
{
    private readonly DataContext _context;

    public FeedbackCaminhoRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FeedbackCaminho>> GetAllAsync()
    {
        return await _context.FeedbackCaminhos.ToListAsync();
    }

    public async Task<FeedbackCaminho?> GetByIdAsync(long id)
    {
        return await _context.FeedbackCaminhos.FindAsync(id);
    }

    public async Task AddAsync(FeedbackCaminho feedback)
    {
        await _context.FeedbackCaminhos.AddAsync(feedback);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var feedback = await _context.FeedbackCaminhos.FindAsync(id);
        if (feedback != null)
        {
            _context.FeedbackCaminhos.Remove(feedback);
            await _context.SaveChangesAsync();
        }
    }
}
