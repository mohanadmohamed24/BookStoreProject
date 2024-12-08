using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreProject.DAL.Data;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Repositories;
using BookStoreProject.BLL.Managers.PublisherMangers;
using BookStoreProject.BLL.ViewModels.PublisherVMS;
using AutoMapper;


namespace BookStoreProject.MVC.Controllers
{
    public class PublishersController : Controller
    {
       
        private readonly IPublisherManger _publisherManger;


        public PublishersController(IPublisherManger publisherManger  )

        {
            _publisherManger = publisherManger;
        }

        // GET: Publishers
        //Publishers/GetALLPublisher
        public async Task<IActionResult> Index()
        {
            var Publisher = await _publisherManger.GetAll();
            return View(Publisher);
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var publisher = await _publisherManger.GetById(id);
            if (id == null)
                return NotFound();
           
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        // GET: Publishers/Create

        [HttpGet]
        public IActionResult Create()
        {
            PublisherInsertVM ViewModeVM = new PublisherInsertVM();
            return View(ViewModeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Name,Description,Address,TelephoneNumber")]*/PublisherInsertVM publisherInsertVM )
        {
            if (ModelState.IsValid)
            {
               await _publisherManger.Add(publisherInsertVM);
                return RedirectToAction(nameof(Index));
            }

            return View(publisherInsertVM);
        }
        // GET: Publishers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var publisher = await _publisherManger.GetById(id);

            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,TelephoneNumber")] PublisherUpdateVM publisher)
        {
            //new
            if (id != publisher.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                await _publisherManger.Update(publisher);

                return RedirectToAction(nameof(Index));
            }
                     
            return View(publisher);
        }
        // GET: Publishers/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null |id==0)
            {
                NotFound();
            }
            var publisher =await _publisherManger.GetById(id);          
            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _publisherManger.Delete(id);
            return RedirectToAction(nameof(Index));
        }       
    }
}

