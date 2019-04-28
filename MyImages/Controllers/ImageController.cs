using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyImages.Uow;
using MyImages.Models;
using MyImages.Services;

namespace MyImages.Controllers
{
    public class ImageController : Controller
    {
        ImageUow _uow;
        public IImageServices _service = new ImageServices();
            

        public ImageController()
        {
            this._uow = new ImageUow();
        }

        // GET: Images
        public ActionResult Index()
        {
            return View(_uow.Repository.FindAll());
        }

        // GET: Images/Details/5
        public ActionResult Details(string id)
        {
            return View(_uow.Repository.FindById(id));
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageModel ImageModel, IFormFile Image)
        {
            if (_service.ValidNumberOfImagesUploaded(_uow))
            {
                if (_service.ValidPngFile(Image))
                {
                    try
                    {
                        _service.BuildImagesByteArray(ImageModel, Image, _service);
                        _uow.Repository.Add(ImageModel);
                        _uow.Commit();

                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }



        // GET: Images/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_uow.Repository.FindById(id));
        }

        // POST: Images/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ImageModel image)
        {
            try
            {

                _uow.Repository.Edit(image);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Images/Delete/5
        public ActionResult Delete(string id)
        {
            return View(_uow.Repository.FindById(id));
        }

        // POST: Images/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, ImageModel image)
        {
            try
            {
                this._uow.Repository.Remove(this._uow.Repository.FindById(id));
                this._uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}