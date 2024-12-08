using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data;
using BookStoreProject.BLL.mapper;
using BookStoreProject.DAL.Repositories;
using BookStoreProject.BLL.Managers.PublisherMangers;
using BookStoreProject.BLL.Managers.CartMangers;


namespace BookStoreProject.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Register
            builder.Services.AddScoped(typeof(IGenericRbo<>), typeof(GenericRbo<>));
           



            // register automapper 
            builder.Services.AddAutoMapper(map => map.AddProfile(new MapperProfile()));
            //register mvc.razor.runtime
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            //register IPublisherRebo,IPublisherManger
            builder.Services.AddScoped<IPublisherRebo, PublisherRebo>();
            builder.Services.AddScoped<IPublisherManger, PublisherManger>();
            //register ICartRebo,ICartManger
            builder.Services.AddScoped<ICartRebo, CartRebo>();
            builder.Services.AddScoped<ICartManger, CartManger>();
            
            // to deduce type of entity in geenric repositroy when injected in cotrol
            builder.Services.AddScoped(typeof(IGenericRbo<>), typeof(GenericRbo<>));
            //connectionString 

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(connectionString));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
