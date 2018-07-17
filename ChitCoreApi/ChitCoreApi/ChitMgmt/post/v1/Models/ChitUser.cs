using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitCoreApi.ChitMgmt.post.v1.Models
{
    public class ChitUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Chit")]
        public int ChitId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual Chit Chit { get; set; }

        public virtual User User { get; set; }
    }
}
