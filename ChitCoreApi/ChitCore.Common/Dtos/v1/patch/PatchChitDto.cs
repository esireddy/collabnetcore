using ChitCore.Common.Dtos.v1.post;
using System;
using System.Collections.Generic;

namespace ChitCore.Common.Dtos.v1.patch
{
    public class PatchChitDto
    {
        #region Properties

        public string Name { get; set; }

        public int Value { get; set; }

        public int NoOfMonths { get; set; }

        public int NoOfUsers { get; set; }

        public int ManagerId { get; set; }

        public DateTime? AuctionDate { get; set; }

        public IEnumerable<CreateChitUser> ChitUsers { get; set; } = new List<CreateChitUser>();

        #endregion Properties
    }
}
