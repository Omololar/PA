using AgroEX.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroEX.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products{get;set;}
        public DbSet<User> Users{get;set;}
        public DbSet<UserType> UserTypes{get;set;}
        public DbSet<Photo> Photos{get;set;}
   
    }
}