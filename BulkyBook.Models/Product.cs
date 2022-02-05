using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
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

        [ValidateNever]
        public string Imageurl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        
        public Category Category { get; set; }

        [Required]
        public int CoverTypeId { get; set; }
       
        public CoverType CoverType { get; set; }
    }
}