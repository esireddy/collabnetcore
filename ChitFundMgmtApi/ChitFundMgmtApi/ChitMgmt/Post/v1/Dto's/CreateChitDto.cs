using System;
using System.ComponentModel.DataAnnotations;

namespace ChitFundMgmtApi.ChitMgmt.Post.v1.Dto_s
{
    public class CreateChitDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Value is required")]
        public int Value { get; set; }
        [Required(ErrorMessage = "NoOfMonths is required")]
        public int NoOfMonths { get; set; }
        [Required(ErrorMessage = "NoOfUsers is required")]
        public int NoOfUsers { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int StatusId { get; set; } = (int)ChitMgmtApiConstants.ChitStatus.New;
    }
}
