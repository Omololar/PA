using System.ComponentModel.DataAnnotations;

namespace AgroEX.API.Dtos
{
    public class UserModel
    {
       [Required]
        public string username{get;set;}
        [Required]
        [StringLength(8, MinimumLength =4, ErrorMessage=" Password must be atleast 8 characters long")]
        public string password{get;set;}
        public string userType{get;set;}
    }
}