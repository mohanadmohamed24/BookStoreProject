using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProject.DAL.Repositories
{
    public class CartRebo : GenericRbo<Cart>, ICartRebo
    {
        private readonly BookStoreDbContext _context;

        public CartRebo(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable <Cart>> GetAllCart()
        {
            return await _context.Carts
                           .Include(c => c.book)
                           .Include(c => c.User)

                           .ToListAsync();
        }

        public async Task<Cart> GetByIdCart(int id)
        {
            return await _context.Carts
                                       .Include(c => c.book)
                                       .Include(c => c.User)
                                       .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}