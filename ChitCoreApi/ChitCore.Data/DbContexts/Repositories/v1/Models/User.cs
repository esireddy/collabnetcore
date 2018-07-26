using System;
using System.Collections.Generic;

namespace ChitCore.Data.v1.Models
{
    public partial class User
    {
        public User()
        {
            AuctionDetails = new HashSet<AuctionDetail>();
            ChitAdministrator = new HashSet<ChitAdministrator>();
            ChitUsers = new HashSet<ChitUser>();
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Minitial { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int StatusId { get; set; }
        public int UserTypeId { get; set; }

        public ICollection<AuctionDetail> AuctionDetails { get; set; }
        public ICollection<ChitAdministrator> ChitAdministrator { get; set; }
        public ICollection<ChitUser> ChitUsers { get; set; }
        public ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
