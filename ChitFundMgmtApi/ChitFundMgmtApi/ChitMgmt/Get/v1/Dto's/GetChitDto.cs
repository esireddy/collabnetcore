using System;

namespace ChitFundMgmtApi.ChitMgmt.Get.v1.Dto_s
{
    public class GetChitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int NoOfMonths { get; set; }
        public int NoOfUsers { get; set; }
        public string CreateDate { get; set; }
        public string StatusText { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }        
    }
}
