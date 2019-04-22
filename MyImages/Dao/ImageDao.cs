using Microsoft.EntityFrameworkCore;
using MyImages.Data;
using MyImages.Models;
using MyImages.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyImages.Dao
{
    public class ImageDao : DbContext
    {
        public ContextApp context = new ContextApp();
        public Repository<ImageModel> _repository;

        public Repository<ImageModel> Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Repository<ImageModel>(context);
                }
                return _repository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

    }
}
