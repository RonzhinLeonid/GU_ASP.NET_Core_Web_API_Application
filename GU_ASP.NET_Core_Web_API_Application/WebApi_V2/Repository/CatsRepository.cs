﻿using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;

namespace WebApi_V2.Repository
{
    public class CatsRepository : ICatsRepository
    {
        private readonly ApplicationDataContext _context;

        public CatsRepository(ApplicationDataContext context) => _context = context;

        public async Task Add(Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Cat>> Get()
        {
            return await _context.Cats.ToListAsync();
        }

        public async Task Delete(int id)
        {
            var catDelete = await _context.Cats.SingleOrDefaultAsync(t => t.Id == id);
            if (catDelete is null) return;
            _context.Cats.Remove(catDelete);
            await _context.SaveChangesAsync();
        }

        
        public async Task Update(Cat cat)
        {
            _context.Cats.Update(cat);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Cat>> GetFilterName(SearchCatWithPageRequest searchWithPage)
        {
            if (searchWithPage.Page < 1) return new List<Cat>();

            return await _context.Cats
                .Where(p => p.Nickname.ToLower().Contains(searchWithPage.Nickname.ToLower()))
                .Skip((searchWithPage.Page - 1) * searchWithPage.Size)
                .Take(searchWithPage.Size)
                .ToListAsync();
        }
        public async Task<IList<Cat>> GetFilterName(SearchCatRequest search)
        {
            return await _context.Cats
                .Where(p => p.Nickname.ToLower().Contains(search.Nickname.ToLower()))
                .ToListAsync();
        }
    }
}
