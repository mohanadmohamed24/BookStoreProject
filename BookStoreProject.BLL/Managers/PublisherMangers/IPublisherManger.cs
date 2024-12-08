using BookStoreProject.BLL.ViewModels.PublisherVMS;

namespace BookStoreProject.BLL.Managers.PublisherMangers
{
    public interface IPublisherManger
    {
        Task<IEnumerable<PublisherReadVM>> GetAll();

        Task<PublisherReadVM> GetById(int id);

        public Task Add(PublisherInsertVM publisherInsertVM);

        public Task Update(PublisherUpdateVM publisherUpdateVM);

        public Task Delete(int id);



    }
}
