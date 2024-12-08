using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories
{
    public interface IGenericRbo< T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T?> GetById(object id);

        public Task Insert(T entity);

        public Task Update(T entity);

        public Task Delete(object id);

        public Task save();

    }
}
