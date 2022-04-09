using System.Collections.Generic;

namespace Pc.Core.DTO
{
    public class ProductReviewDTO
    {
        public List<ProductReview> ProductReview { get; set; }
        public List<ProductRatingDTO> ProductRating { get; set; }
    }
}