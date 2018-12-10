using System.Collections.Generic;

namespace AgroEX.API.Dtos
{
     public class ProductModel
    {         
        public string ProductName{get;set;}        
        public double Quantity{get;set;}
        public bool InStock{get;set;}
        public bool StoreProduct{get;set;}  
        public decimal price{get;set;}
        public ICollection<ProductPhoto> Photo{get;set;}
        public bool IsAvailble {get;set;}
        public string Description{get;set;}
        public string Url {get;set;}       

    }

}