using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.ViewModels.CartVMS
{
    public class CartUpdateVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookId { get; set; }

        public int UserID { get; set; }
    }
}
