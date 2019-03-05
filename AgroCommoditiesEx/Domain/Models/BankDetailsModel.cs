using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Models
{
    public class BankDetailsModel : Model
    {
        public int BankId { get; set; }
        public string ContactAddress { get; set; }
        public string BankName { get; set; }
        [DisplayName("Bank Account Number")]
        public string BankAccountNo { get; set; }
        [DisplayName(" Account Name")]
        public string AccountName { get; set; }
        
        public UserModel User { get; set; }
        public string UserId { get; set; }

    }
}
