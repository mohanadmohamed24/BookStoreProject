using BookStoreProject.DAL.Data;
using BookStoreProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Repositories
{
    public class PublisherRebo : GenericRbo<Publisher>, IPublisherRebo
    {

        public PublisherRebo(BookStoreDbContext _context) : base(_context)
        {

        }
       

    }
}
