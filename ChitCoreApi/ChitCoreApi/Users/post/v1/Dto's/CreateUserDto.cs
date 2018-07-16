using System.ComponentModel.DataAnnotations;

namespace ChitCoreApi.Users.post.v1.Dto_s
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

        #endregion Properties
    }
}
