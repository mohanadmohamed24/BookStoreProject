using AutoMapper;
using BookStoreProject.BLL.ViewModels.CartVMS;
using BookStoreProject.BLL.ViewModels.PublisherVMS;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.Managers.CartMangers
{
    public class CartManger : ICartManger
    {
        private readonly ICartRebo _cartRebo;
        private readonly IMapper _mapper;
        public CartManger(ICartRebo cartRebo ,IMapper mapper)
        {
            _cartRebo = cartRebo;
            _mapper = mapper;
        }

        // Add

        public async Task Add(CartInsertVM cartInsertVM)
        {
            await _cartRebo.Insert(_mapper.Map<Cart>(cartInsertVM));
            await _cartRebo.save();
        }

        //Delete

        public async Task Delete(int id)
        {
            await _cartRebo.Delete(id);
            await _cartRebo.save();
        }

        //getAll

        public async Task<IEnumerable<CartReadVM>> GetAll()
        {
            return _mapper.Map<List<CartReadVM>>(await _cartRebo.GetAllCart());
        }

        //get by Id

        public async Task<CartReadVM> GetById(int id)
        {
            return _mapper.Map<CartReadVM>(await _cartRebo.GetByIdCart(id));
        }
        //update  

        public async Task Update(CartUpdateVM cartUpdateVM)
        {
            var car = _mapper.Map<CartUpdateVM, Cart>(cartUpdateVM,await _cartRebo.GetById(cartUpdateVM.Id));
            await _cartRebo.Update(car);
            await _cartRebo.save();
        }
    }
}
