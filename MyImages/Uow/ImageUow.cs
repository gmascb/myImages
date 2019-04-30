using Microsoft.EntityFrameworkCore;
using MyImages.Data;
using MyImages.Models;
using MyImages.Repository;

namespace MyImages.Uow
{
    public class ImageUow : DbContext
    {
        public ContextApp context = new ContextApp();
        public RepositoryGeneric<ImageModel> _repository;

        public RepositoryGeneric<ImageModel> Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new RepositoryGeneric<ImageModel>(context);
                }
                return _repository;
            }
        }

        //public void Commit()
        //{
        //    context.SaveChanges();
        //}
    }
}