using System;
using System.Collections.Generic;

namespace ChitCore.Data.v1.Models
{
    public partial class ChitAdministrator
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChitId { get; set; }

        public Chit Chit { get; set; }
        public User User { get; set; }
    }
}
