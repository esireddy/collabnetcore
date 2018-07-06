using System.ComponentModel.DataAnnotations;

namespace ChitCoreApi.ChitMgmt.post.v1.Dto_s
{
    public class CreateChitDto
    {
        #region Properties

        [Required]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public int NoOfMonths { get; set; }

        [Required]
        public int NoOfUsers { get; set; }

        #endregion Properties
    }
}
