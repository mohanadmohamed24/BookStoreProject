using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories
{
    public interface  ICartRebo: IGenericRbo<Cart>
    {
        public Task<IEnumerable<Cart>> GetAllCart();

        public Task<Cart> GetByIdCart(int id);

    }
}
