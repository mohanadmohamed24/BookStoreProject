﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.DAL.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }


        public int UserID { get; set; }
        public User User { get; set; }




        //  public ICollection<Book> Books { get; set; } = new HashSet<Book>();



        //public int ProductId { get; set; }
        //[ForeignKey("ProductId")]
        //[ValidateNever]
        //public Product Product { get; set; }
        //[Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        //public int Count { get; set; }

        //public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        //[ValidateNever]
        //public ApplicationUser ApplicationUser { get; set; }

        //[NotMapped]
        //public double Price { get; set; }


    }
}
