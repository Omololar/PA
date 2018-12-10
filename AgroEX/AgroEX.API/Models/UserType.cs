using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgroEX.API.Models
{
    public class UserType
    {
         public int Id{get;set;}
         public string Name {get;set;}
         public ICollection<User> Users{get;set;}

         public UserType()
         {
             Users=new Collection<User>();
         }
    }
}