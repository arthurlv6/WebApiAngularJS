using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.DataContext.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(100)]
        public double Price { get; set; }
        [DefaultValue(80)]
        public double Cost { get; set; }
        public string Profile { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Product Code is required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Product Code min length is 6 characters")]
        public string ProductCode { get; set; }
    }
}
