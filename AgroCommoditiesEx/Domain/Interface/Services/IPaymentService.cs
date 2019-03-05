using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IPaymentService
    {
        //Task<UserPaymentModel> GetTransaction(string @ref);
       // Task<UserPaymentModel> SetTransaction(UserModel model);
        Task<List<BankDetailsModel>> GetBanks();
    }
}
