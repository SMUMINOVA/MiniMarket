using System.Collections.Generic;

namespace Market.Models
{
    public class Category
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public List<Product> Products = new List<Product>();
    }
}