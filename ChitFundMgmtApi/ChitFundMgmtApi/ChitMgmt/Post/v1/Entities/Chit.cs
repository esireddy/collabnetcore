using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitFundMgmtApi.ChitMgmt.Post.v1.Entities
{
    public class Chit
    {
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
        [Required]
        public int StatusId { get; set; }
    }
}
