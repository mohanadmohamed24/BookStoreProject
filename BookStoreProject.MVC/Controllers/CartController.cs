using BookStoreProject.BLL.Managers.CartMangers;
using BookStoreProject.BLL.Managers.PublisherMangers;
using BookStoreProject.BLL.ViewModels.CartVMS;
using BookStoreProject.BLL.ViewModels.PublisherVMS;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProject.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManger _cartManger;
        public CartController(ICartManger cartManger)
        {
            _cartManger= cartManger;
        }
        public async Task<IActionResult> Index()
        {
            var Cart = await _cartManger.GetAll();
            return View(Cart); 
        }

        public async Task< IActionResult> Details(int id)
        {
            var cart =await _cartManger.GetById(id);
            
            //if (cart == null)
            //{
            //    return NotFound();
            //} 
            return View("Details", cart);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CartInsertVM ViewModeVM = new CartInsertVM();
            return View(ViewModeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CartInsertVM cartInsertVM)
        {
            if (ModelState.IsValid)
            {
                await _cartManger.Add(cartInsertVM);
                return RedirectToAction(nameof(Index));
            }

            return View(cartInsertVM);
        }
    }
}
