using Domain.Interface.Managers;
using Domain.Interface.Repositories;
using Domain.Interface.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class BankManager : IBankManager
    {
        private readonly IBankRepository _bankrepo;
        private readonly IPaymentService _payment;
        private readonly IUserRepository _userRepo;

        public BankManager(IBankRepository bankrepo, IPaymentService payment,
            IUserRepository userRepo)
        {
            _bankrepo = bankrepo;
            _payment = payment;
            _userRepo = userRepo;
        }
        public async Task<BankDetailsModel> CreateBankDetails(BankDetailsModel model)
        {

            var user = await _userRepo.GetById(model.UserId);
            var bankdetails = new BankDetailsModel()
            {
                BankAccountNo = model.BankAccountNo,
                BankName = model.BankName,
                AccountName = model.AccountName,
                ContactAddress = model.ContactAddress,
                UserId = model.UserId
            };
            var usermodel = new UserModel()
            {
                Id = model.UserId,
                AccountName = model.AccountName,
                BankAccountNo = model.BankAccountNo,
                ContactAddress = model.ContactAddress,
                BankName = model.BankName
            };
            var saveUserbank = _userRepo.AddUserBankDetails(usermodel);

            return await _bankrepo.CreateBankDetails(bankdetails);
        }

        public async Task<List<BankDetailsModel>> getbanks()
        {

            var banks = await _payment.GetBanks();


            return banks;
        }
    }
}
