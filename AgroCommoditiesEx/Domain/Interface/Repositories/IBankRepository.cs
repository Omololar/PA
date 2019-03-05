using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IBankRepository
    {
        Task<BankDetailsModel> CreateBankDetails(BankDetailsModel model);
    }
}
