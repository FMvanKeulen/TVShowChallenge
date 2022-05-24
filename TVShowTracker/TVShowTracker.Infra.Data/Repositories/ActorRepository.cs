using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;
using TVShowTracker.Infra.Data.Context;

namespace TVShowTracker.Infra.Data.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<Actor> Create(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetById(int? id)
        {
            return await _context.Actors.FindAsync(id);
        }

        public async Task<IEnumerable<Actor>> GetShowsByActor(Actor actor)
        {
            return await _context.Actors.Include(s => s.Shows).ToListAsync();
        }

        public async Task<Actor> Remove(Actor actor)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> Update(Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
    }
}