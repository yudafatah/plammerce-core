using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pc.Core.Entities.Product
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        [Display(Name = "Discounted Price")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [Required]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Mrp { get; set; }

        public string Description { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        public int ViewCount { get; set; } = 0;

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Rating { get; set; } = 5;

        public int PurchasedCount { get; set; } = 0;

        [MaxLength(255)]
        [Display(Name = "Browse Image (248X275)")]
        public string ImagePath { get; set; }

        public int VendorId { get; set; }

        public int ShippingCharges { get; set; } //

        public int ReviewCount { get; set; } = 0;

        public bool ShowInHomePage { get; set; } = false;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? PublishedDate { get; set; }

        public List<ProductFeature> ProductFeatures { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<Category> Categories { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
