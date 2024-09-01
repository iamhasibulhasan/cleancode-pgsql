using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CleanCode.Domain.Entities.Authentication.Roles
{
    public sealed class Role : IdentityRole<int>
    {
        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public int StatusId { get; set; }
    }
}
