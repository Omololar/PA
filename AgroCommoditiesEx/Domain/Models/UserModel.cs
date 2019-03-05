using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class UserModel : Model
    {
        public string StringRoles { get; set; }
        public string Id { get; set; }
        //public string token { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "First name required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lasr name required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Mobile No")]
        public string PhoneNumber { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();
        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public PaymentStatus Status { get; set; }
        [Required(ErrorMessage = "Select your registration category")]
        [DisplayName("Register as")]
        public string UserType { get; set; }
        [DisplayName("Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords did not match")]
        public string ConfirmPassword { get; set; }
        //public ICollection<UserPaymentModel> Payment = new List<UserPaymentModel>();
        public decimal WalletBalance { get; set; } = 0;
        public decimal Charges { get; set; }
        public string NotifyURL { get; set; }
        public string MerchantRef { get; set; }
        public string RedirectUrl { get; set; }
        public string Reference { get; set; }
        public decimal UnitValue { get; set; } = 1.00M;
        public decimal UnitCurrencyValue { get; set; } = 1.00M;
        public bool IsApproved { get; set; }
        public decimal CurrentUnit { get; set; }
        public string ChacheKey { get; set; }

        public string ContactAddress { get; set; }
        public string BankName { get; set; }
        [DisplayName("Bank Account Number")]
        public string BankAccountNo { get; set; }
        [DisplayName(" Account Name")]
        public string AccountName { get; set; }
        public ICollection<ProductModel> Products { get; set; }

    }
    public enum PaymentStatus { Pending, Succes, Failed }
    //public enum UserType { Farmer, Manufacturer,Investor, WholeSaler }

}
