using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Trash
    {
        public int Id{get;set;}
        [Required(ErrorMessage ="Name can't be empty")]
        public string ProductsName{get;set;}
        [Required(ErrorMessage ="Cost can't be empty")]
        public double ProductsCost{get;set;}
        public string Adress{get;set;}
        public string DeliveryTime{get;set;}
        public string PhoneNumber{get;set;}
    }
}