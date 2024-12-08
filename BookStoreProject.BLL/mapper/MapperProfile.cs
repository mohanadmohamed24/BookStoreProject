using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Repositories;
using BookStoreProject.BLL.ViewModels.PublisherVMS;
using BookStoreProject.BLL.ViewModels.CartVMS;

namespace BookStoreProject.BLL.mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            //create publisher:
             CreateMap<Publisher, PublisherUpdateVM>().ReverseMap();
            CreateMap<Publisher, PublisherInsertVM>().ReverseMap();
            CreateMap<Publisher, PublisherReadVM>().ReverseMap();
            //creat cart
            CreateMap<Cart,CartUpdateVM>().ReverseMap();
            CreateMap<Cart,CartInsertVM>().ReverseMap();
            CreateMap<Cart,CartReadVM>().ReverseMap();


        }
    }
}
