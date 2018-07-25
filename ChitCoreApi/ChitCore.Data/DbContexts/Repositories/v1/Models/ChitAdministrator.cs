using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChitCore.Data.v1.Models
{
    public class ChitAdministrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ChitId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Manager { get; set; }

        [ForeignKey("ChitId")]
        public virtual Chit Chit { get; set; }
    }
}
