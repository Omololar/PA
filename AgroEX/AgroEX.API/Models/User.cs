namespace AgroEX.API.Models
{
    public class User
    {
        public int Id{get;set;}
        public string Username{get;set;}
        public byte[] PasswordHash {get;set;}
        public byte[] Passwordsalt{get;set;}

        public UserType UserType{get;set;}
        public int UserTypeId{get;set;}
    }
}