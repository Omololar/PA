using Domain.Interface.Repositories;
using Domain.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly DbContext _context;
        public BankRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<BankDetailsModel> CreateBankDetails(BankDetailsModel model)
        {
            var bankdetails = new BankDetails().Assign(model);
            _context.Set<BankDetails>().Add(bankdetails);
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
