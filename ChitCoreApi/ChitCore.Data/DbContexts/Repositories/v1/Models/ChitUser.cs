using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChitCore.Data.v1.Models
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

        [Required]
        public int ChitUserTypeId { get; set; }

        [ForeignKey("ChitId")]
        public virtual Chit Chit { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
