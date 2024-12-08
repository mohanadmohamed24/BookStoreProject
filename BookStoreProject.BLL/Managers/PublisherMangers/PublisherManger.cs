using AutoMapper;
using BookStoreProject.BLL.ViewModels.PublisherVMS;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.Managers.PublisherMangers
{
    public class PublisherManger : IPublisherManger
    {
        private readonly IPublisherRebo _publisherRebo;
        private readonly IMapper _mapper;

        public PublisherManger(IPublisherRebo publisherRebo, IMapper mapper)
        {
            _publisherRebo = publisherRebo;
            _mapper = mapper;
        }


        // Add
        public async Task Add(PublisherInsertVM publisherInsertVM)
        {
            await _publisherRebo.Insert(_mapper.Map<Publisher>(publisherInsertVM));
            await _publisherRebo.save();
        }


        //Delete
        public async Task Delete(int id)
        {
            await _publisherRebo.Delete(id);
            await _publisherRebo.save();
        }

        //getAll
        public async Task<IEnumerable<PublisherReadVM>> GetAll()
        {

            return _mapper.Map<List<PublisherReadVM>>(await _publisherRebo.GetAll());
        }

        //get by Id
        public async Task<PublisherReadVM> GetById(int id)
        {
            return _mapper.Map<PublisherReadVM>(await _publisherRebo.GetById(id));
        }


        //update  
        public async Task Update(PublisherUpdateVM publisherUpdateVM)
        {
            var Pup = _mapper.Map<PublisherUpdateVM, Publisher>(publisherUpdateVM, await _publisherRebo.GetById(publisherUpdateVM.Id));
            //var pup = await _publisherRebo.GetById(publisherUpdateVM.Id);

            //pup.Address = publisherUpdateVM.Address;
            //pup.Name = publisherUpdateVM.Name;
            //pup.TelephoneNumber = publisherUpdateVM.TelephoneNumber;
            //pup.Description = publisherUpdateVM.Description;

            await _publisherRebo.Update(Pup);
            await _publisherRebo.save();
        }

       
    }
}
