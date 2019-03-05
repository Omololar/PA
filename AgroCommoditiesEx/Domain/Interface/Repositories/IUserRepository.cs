using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> AddUserBankDetails(UserModel model);
        Task<UserModel> GetById(string userId);
        Task<(bool Status, string Message)> CreateUser(UserModel model);
        Task<(bool Status, string Message)> AddUserToRole(UserModel user, string[] roleId);

        Task<UserModel> VerifyUser(string username, string password);
    }
}
