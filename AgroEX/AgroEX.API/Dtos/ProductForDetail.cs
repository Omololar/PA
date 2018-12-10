using System.Collections.Generic;

namespace AgroEX.API.Dtos
{
  public class ProductForDetail
    {
        public int Id {get;set;}
        public string ProductName{get;set;}        
        public double Quantity{get;set;}
        public bool InStock{get;set;}
        public bool StoreProduct{get;set;}      
        public decimal price{get;set;}      
       public string PhotoUrl {get;set;}
        public ICollection<PhotosForDetail> Photos {get;set;}
       
       
    }

}