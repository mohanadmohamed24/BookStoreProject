using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data.Models;
using System.Net;

namespace BookStoreProject.DAL.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }

        public BookStoreDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(e => new {e.BookId ,e.AuthorId});
            modelBuilder.Entity<BookOrder>().HasKey(e => new {e.BookId ,e.OrderId});
            modelBuilder.Entity<BookPurchase>().HasKey(e => new {e.BookId ,e.PurchaseId});

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DiscountCoupon)
                .WithOne(dc => dc.Order)
                .HasForeignKey<DiscountCoupon>(dc => dc.OrderID);
            //new 
        
            var category = new Category
            {
                Id = 7,
                Name = "booker",
            };
            modelBuilder.Entity<Category>().HasData(category);
            var cart = new Cart
            {
                Id=6,
                BookId = 5,
                Quantity = 300,
                UserID = 3

            };
            modelBuilder.Entity<Cart>().HasData(cart);
            var book = new Book
            {
                Id = 5,
                Title = "fatma",
                ISBN = "yassin",
                Price = 455,
                PublishedDate = DateTime.Now,
                Description = "good",
                StockQuantity = 15,
                IsDeleted = true,
                CategoryID = 5,
                ImgUrl = "Fatma.png",
                PublisherID = 2,

            };
            modelBuilder.Entity<Book>().HasData(book);



        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<BookPurchase> BookPurchases { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
