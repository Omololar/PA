using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgroEX.API.Models
{
    public class Product
    {
   
        public int Id {get;set;}
        public string ProductName{get;set;}        
        public double Quantity{get;set;}
        public bool InStock{get;set;}
        public bool StoreProduct{get;set;}      
        public decimal price {get;set;}       
        public ICollection<Photo> Photos {get;set;}
       
        public Product()
        {
           Photos =new Collection<Photo>();
        }
        
    

    }
}