using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteShop_Models
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please enter a valid name...")]
        public string Name { get; set; }
    }
}
