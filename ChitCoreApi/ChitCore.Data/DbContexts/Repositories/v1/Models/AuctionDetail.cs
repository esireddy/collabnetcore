using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChitCore.Data.v1.Models
{
    public class AuctionDetail
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ChitId { get; set; }

        [Required]
        public int UserId { get; set; }  // Bidded by this user

        [Required]
        public DateTime ActionedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal BidAmount { get; set; }

        [Required]
        public DateTime AmountDueBy { get; set; } = DateTime.UtcNow.AddDays(7);
        
        #endregion Properties
    }
}
