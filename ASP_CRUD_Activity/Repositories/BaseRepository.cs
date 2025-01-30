﻿using System.Linq.Expressions;
using ASP_CRUD_Activity.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_CRUD_Activity.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;

        }

        public async Task<T> Get(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);

        }


        public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.ToListAsync();
            //include/ fetch something related to the book and define in the interface
        }

       
    }
}
