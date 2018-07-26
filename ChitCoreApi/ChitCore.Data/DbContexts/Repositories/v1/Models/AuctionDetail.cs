using System;
using System.Collections.Generic;

namespace ChitCore.Data.v1.Models
{
    public partial class AuctionDetail
    {
        public int Id { get; set; }
        public int ChitId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedDate { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime AmountDueBy { get; set; }

        public Chit Chit { get; set; }
        public User User { get; set; }
    }
}
