using System.ComponentModel.DataAnnotations;

namespace ChitCore.Common.v1.Dtos
{
    public class CreateUserDto
    {
        #region Properties

        [Required]
        public string Firstname { get; set; }

        public string MInitial { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        #endregion Properties
    }
}
