using ECart.Models.Enum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pc.Core.Entities
{
    public class ApplicationUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        [BsonId]
        public string Id { get; set; }

        [MaxLength(150)]
        public string ReferCode { get; set; }
        [MaxLength(150)]
        public string MyReferCode { get; set; }
        [MaxLength(150)]
        public string PlainPassword { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(150)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(15)]
        public string PinCode { get; set; }
        public int VendorId { get; set; }
        public int Role { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
    }
}
