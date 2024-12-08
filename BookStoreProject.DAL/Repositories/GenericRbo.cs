using BookStoreProject.DAL.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories
{
    public class GenericRbo<T> : IGenericRbo<T> where T : class
    {
        protected readonly BookStoreDbContext Context;

        protected readonly DbSet<T> table;
        public GenericRbo(BookStoreDbContext _context)
        {
            Context = _context;
            table = _context.Set<T>();
        }
        // generic get all async
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.AsNoTracking().ToListAsync();
        }
        // generic getbyid async 
        public async Task<T?> GetById(object id)
        {
            return await table.FindAsync(id);
        }
        // generic insert async 
        public async Task Insert(T entity)
        {
            await table.AddAsync(entity);
        }
        // generic update async 
        public async Task Update(T entity)
        {
            table.Update(entity);
        }
        // generic delete async 
        public async Task Delete(object id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                table.Remove(entity);
            }
        }
        // generic saveasync 
        public async Task save()
        {
            await Context.SaveChangesAsync();
        }
    }
}

