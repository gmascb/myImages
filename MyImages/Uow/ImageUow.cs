using Microsoft.EntityFrameworkCore;
using MyImages.Data;
using MyImages.Models;
using MyImages.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyImages.Uow
{
    public class ImageUow : DbContext
    {
        public ContextApp context = new ContextApp();
        public IRepository<ImageModel> _repository;

        public IRepository<ImageModel> Repository { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

    }
}
