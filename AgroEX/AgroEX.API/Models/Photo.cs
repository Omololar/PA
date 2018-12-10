namespace AgroEX.API.Models
{
    public class Photo
    {
        public int Id{get;set;}
        public string Url{get;set;}
        public string Description{get;set;}
        public bool IsAvailable {get;set;}
        public Product Product {get;set;}
        public int ProductId {get;set;}
    }
}