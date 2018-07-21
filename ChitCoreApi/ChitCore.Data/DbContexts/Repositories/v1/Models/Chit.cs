using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ChitCore.Common.v1.ChitCoreApiConstants;

namespace ChitCore.Data.v1.Models
{
    public class Chit
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public int NoOfMonths { get; set; }

        [Required]
        public int NoOfUsers { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ChitStatus StatusId { get; set; } = ChitStatus.New;

        public int ManagerId { get; set; }

        public int Commission { get; set; }

        public DateTime? AuctionDate { get; set; }

        public virtual ICollection<ChitUser> ChitUsers { get; set; } = new List<ChitUser>();

        #endregion Properties
    }
}
