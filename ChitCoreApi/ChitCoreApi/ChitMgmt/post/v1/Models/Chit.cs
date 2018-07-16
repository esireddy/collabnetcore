using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ChitCoreApi.ChitCoreApiConstants;

namespace ChitCoreApi.ChitMgmt.post.v1.Models
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

        #endregion Properties
    }
}
