namespace Pc.Core.DTO
{
    public class ProductFilterDTO
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string BrandIds { get; set; }
        public string DiseaseIds { get; set; }
        public string CategoryIds { get; set; }
        public string Prices { get; set; }
        public string ProductIds { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public ProductSortOrderType SortOrder { get; set; }
        public string AffiliateKey { get; set; }
    }
}