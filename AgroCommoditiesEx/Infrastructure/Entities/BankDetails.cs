using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class BankDetails : Entity
    {
        public int Id { get; set; }
        public string ContactAddress { get; set; }
        public string BankName { get; set; }

        public string BankAccountNo { get; set; }
        public string AccountName { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }

    }
}
