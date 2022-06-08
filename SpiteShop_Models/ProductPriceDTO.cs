using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteShop_Models
{
    public class ProductPriceDTO
    {
        public int ID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Size { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 1$")]
        public double Price { get; set; }
    }
}
