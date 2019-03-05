using Domain.Interface.Managers;
using Domain.Interface.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repo;
        private readonly IBankManager _bankrepo;
        public UserManager(IUserRepository repo, IBankManager bankrepo)
        {
            _repo = repo;
            _bankrepo = bankrepo;
        }

        public async Task<BankDetailsModel> AddUserBankDetails(UserModel model)
        {
            var user = await _repo.GetById(model.UserId);

            var bankdetails = _repo.AddUserBankDetails(user);

            return new BankDetailsModel();
        }

        public Task<(bool Status, string Message)> AddUserToRolesAsync(UserModel user, string[] roleIds)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Status, string Message)> CreateUser(UserModel model)
        {
            return _repo.CreateUser(model);
        }

        public async Task<UserModel> GetById(string userId) => await _repo.GetById(userId);

        public Task<UserModel> VerifyUser(string username, string password)
        {
            return _repo.VerifyUser(username, password);
        }
    }
}
