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
        public int ChitId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("ChitId")]
        public virtual Chit Chit { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
