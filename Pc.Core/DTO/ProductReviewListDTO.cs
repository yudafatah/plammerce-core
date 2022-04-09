using Pc.Core.Enums;

namespace Pc.Core.DTO
{
    //[Table("productreview")]
    public class ProductReviewListDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
        public string CreatedDate { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public ProductReviewStatusType Status { get; set; }
    }
}
