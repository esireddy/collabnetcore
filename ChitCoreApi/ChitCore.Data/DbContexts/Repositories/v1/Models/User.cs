using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ChitCore.Common.v1.ChitCoreApiConstants;

namespace ChitCore.Data.v1.Models
{
    public class User
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MInitial { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow; // Customer Since this date. Should not be modifiable, once created

        [Required]
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow; // Customer Since this date. Should not be modifiable, once created

        public int StatusId { get; set; } = (int)CustomerStatus.New;

        [Required]
        public int UserTypeId { get; set; } = (int)UserType.ChitPayer;

        public ICollection<ChitUser> ChitUsers { get; set; }

        public ICollection<ChitAdministrator> ChitAdmins { get; set; }

        #endregion Properties
    }
}
