using BookStoreProject.BLL.ViewModels.CartVMS;
using BookStoreProject.BLL.ViewModels.PublisherVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.Managers.CartMangers
{
    public interface ICartManger
    {
        Task<IEnumerable<CartReadVM>> GetAll();

        Task<CartReadVM> GetById(int id);

        public Task Add(CartInsertVM cartInsertVM );

        public Task Update(CartUpdateVM cartUpdateVM );

        public Task Delete(int id);
    }
}
