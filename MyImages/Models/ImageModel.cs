using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Internal;

namespace MyImages.Models
{
    public class ImageModel
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
