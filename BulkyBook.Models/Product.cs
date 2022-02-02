using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1,10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double FinalPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double FinalPrice50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double FinalPrice100 { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        [Required]
        public int CoverTypeID { get; set; }

        [ForeignKey("CategoryID")]
        public CoverType CoverType { get; set; }






    }
}
