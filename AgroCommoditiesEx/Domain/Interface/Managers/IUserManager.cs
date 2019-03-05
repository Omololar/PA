using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Managers
{
    public interface IUserManager
    {
        Task<UserModel> VerifyUser(string username, string password);
        Task<BankDetailsModel> AddUserBankDetails(UserModel model);
        Task<UserModel> GetById(string userId);
        Task<(bool Status, string Message)> CreateUser(UserModel model);
        Task<(bool Status, string Message)> AddUserToRolesAsync(UserModel user, string[] roleIds);

    }
}
