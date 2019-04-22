using Microsoft.EntityFrameworkCore;
using MyImages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyImages.Data
{
    public class ContextApp : DbContext
    {
        public ContextApp()
            :base()
        {

        }

        public virtual DbSet<ImageModel> Image { get; set; }


        //protected override void OnModelCreating(DbModelBuilder builder)
        //{
        //}

    }
}

