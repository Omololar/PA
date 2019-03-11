using Domain.Interface.Repositories;
using Domain.Models;
using Domain.Utilities;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;
using System.Text.Encodings.Web;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private readonly UserManager<Entities.User> _userManager;
        private readonly INotificationUtility _notification;
        private readonly DbContext _context;

        public UserRepository(UserManager<Entities.User> userManager,  INotificationUtility notification, DbContext context)
        {
            
            _context = context;
            _userManager = userManager;
            _notification = notification;
        }
        public async Task<Domain.Models.UserModel> AddUserBankDetails(UserModel model)
        {

            var bankDetails = _context.Set<Entities.User>().Find(model.Id);
            if (bankDetails == null) throw new Exception("user not found");

            bankDetails.ContactAddress = model.ContactAddress;
            bankDetails.BankName = model.BankName;
            bankDetails.BankAccountNo = model.BankAccountNo;
            bankDetails.BankAccountName = model.AccountName;

            await _context.SaveChangesAsync();

            return model;
        }

        public Task<(bool Status, string Message)> AddUserToRole(UserModel user, string[] roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool Status, string Message)> CreateUser(UserModel model)
        {

            var user = new User().Assign(model);
            user.UserName = model.Email;
           // user.UserId = model.Id;

            var result = await _userManager.CreateAsync(user, model.Password);

            
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),

                    new Claim(ClaimTypes.Name, user.FirstName ?? ""),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
                    new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                    new Claim(ClaimTypes.Surname, model.LastName ?? ""),
                    new Claim(ClaimTypes.Role, model.UserType)

                };
                var claimResult = await _userManager.AddClaimsAsync(user, claims);
               
                if (claimResult.Succeeded)
                {
                    _notification.SendMail(new MailModel
                    {
                        Content =
                      $"Dear {model.FullName} Your account has been created successfully as a {model.UserType}<br />" +
                      $" Your Login Details: <br/> Username : {model.Email} <br/> Password: {model.Password}<br /> click the link below" +
                      $"to login <a href='{HtmlEncoder.Default.Encode(Constants.AGROEX_URL + "/Account/Login")}'>clicking here</a> ",
                        
                        DateCreated = DateTime.Now,
                        Subject = "Account Creation In AgroEX Commodities",
                        To = model.Email
                    });
                    return (true, "The user has been created with the right claims");
                }              

            }
            return (false, "Unable to create the user, try again later");
        }

        public async Task<Domain.Models.UserModel> GetById(string userId)
        {
            //var bankDetails = _context.Set<User>().Find(userId);


            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;

            //Assign Obvious Case
            var model = new Domain.Models.UserModel().Assign(user);

            return model;
        }

        public async Task<UserModel> VerifyUser(string username, string password)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == username);
            if (user == null)
                return null;
            //if (!VerifyPasswordHash(password, user.PasswordHash))
            //    return null;
            var model = new UserModel().Assign(user);
            return model;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt))
            {

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}
