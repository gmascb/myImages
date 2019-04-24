using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyImages.Dao;
using MyImages.Models;

namespace MyImages.Controllers
{
    public class ImageController : Controller
    {
        ImageDao _dao;

        public ImageController()
        {
            this._dao = new ImageDao();
        }

        // GET: Images
        public ActionResult Index()
        {
            return View(_dao.Repository.FindAll());
        }

        // GET: Images/Details/5
        public ActionResult Details(string id)
        {
            return View(_dao.Repository.FindById(id));
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageModel ModelOnly, IFormFile Image)
        {
            var arquivo = Image;

            try
            {
                if (arquivo.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        arquivo.CopyToAsync(stream);
                        ModelOnly.Image = stream.ToArray();
                    }
                }
                _dao.Repository.Add(ModelOnly);
                _dao.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Images/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_dao.Repository.FindById(id));
        }

        // POST: Images/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ImageModel image)
        {
            try
            {

                _dao.Repository.Edit(image);
                _dao.Commit();
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
            return View(_dao.Repository.FindById(id));
        }

        // POST: Images/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, ImageModel image)
        {
            try
            {
                this._dao.Repository.Remove(this._dao.Repository.FindById(id));
                this._dao.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}