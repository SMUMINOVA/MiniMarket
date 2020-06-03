using System.Collections.Generic;

namespace Market.Models
{
    public class Trash
    {
        public int Id{get;set;}
        public List<Product> Products{get;set;} = new List<Product>();
    }
}