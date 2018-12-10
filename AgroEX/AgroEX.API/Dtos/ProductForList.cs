namespace AgroEX.API.Dtos
{
    public class ProductForList
    {
        public int Id {get;set;}
        public string ProductName{get;set;}        
        public double Quantity{get;set;}
        public bool InStock{get;set;}
        public bool StoreProduct{get;set;}
        public decimal price{get;set;}
        public string PhotoUrl {get;set;}
    }
}