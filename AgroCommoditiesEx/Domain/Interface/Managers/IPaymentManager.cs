using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Managers
{
   public interface IPaymentManager
    {
        Task<BankPaymentModel> CreateAccount();
    }
}
