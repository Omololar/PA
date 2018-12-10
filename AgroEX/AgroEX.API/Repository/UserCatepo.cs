using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AgroEX.API.Data;
using AgroEX.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroEX.API.Repository
{ public class UserCatRepo
    {
        private readonly DataContext _context;
        public UserCatRepo(DataContext context)
        {
            _context=context;
        }
        public IEnumerable<UserType> Find(Expression<Func<UserType, bool>> usercat){
            return _context.Set<UserType>().Where(usercat);
        } 
        public async Task<IEnumerable<UserType>> UserTypes()
        {
            var usercat= await _context.Set<UserType>().ToListAsync();
            return  usercat;
        }
    }

}