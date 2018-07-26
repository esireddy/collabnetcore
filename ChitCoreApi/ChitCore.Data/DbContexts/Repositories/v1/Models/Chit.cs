using System;
using System.Collections.Generic;

namespace ChitCore.Data.v1.Models
{
    public partial class Chit
    {
        public Chit()
        {
            AuctionDetails = new HashSet<AuctionDetail>();
            ChitUsers = new HashSet<ChitUser>();
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int NoOfMonths { get; set; }
        public int NoOfUsers { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public int ManagerId { get; set; }
        public int Commission { get; set; }
        public DateTime? AuctionDate { get; set; }

        public User Manager { get; set; }
        public ChitAdministrator ChitAdministrator { get; set; }
        public ICollection<AuctionDetail> AuctionDetails { get; set; }
        public ICollection<ChitUser> ChitUsers { get; set; }
        public ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
