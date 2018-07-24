using ChitCore.Common.Dtos.v1.get;
using System;
using System.Collections.Generic;
using static ChitCore.Common.v1.ChitCoreApiConstants;

namespace ChitCore.Common.v1.Dtos
{
    public class GetChitDto
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public int NoOfMonths { get; set; }

        public int NoOfUsers { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ChitStatus StatusId { get; set; }

        public string StatusText { get; set; }

        public int ManagerId { get; set; }

        public string Manager { get; set; }        

        public DateTime? AuctionDate { get; set; }

        public IEnumerable<GetChitUserDto> ChitUsers { get; set; } = new List<GetChitUserDto>();

        public IEnumerable<GetUserDto> Users { get; set; } = new List<GetUserDto>();

        #endregion Properties
    }
}
