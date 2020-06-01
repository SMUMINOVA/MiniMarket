using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Product
    {
        public int Id{get;set;}
        [Required(ErrorMessage ="Name can't be empty")]
        public string Name{get;set;}
        [Required(ErrorMessage ="Cost can't be empty")]
        public double Cost{get;set;}
        public int CategoryId{get;set;}
        public Category Category{get;set;}
    }
}