﻿using BECase.Common.Enums.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BECase.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public int StatusId { get; set; } = (int)EntityStatus.Active;
        [NotMapped]
        public string? StatusText { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Customer? Customer { get; set; }
        public List<Invoice>? Invoices { get; set; }

        public virtual ICollection<JwtRefreshToken> JwtRefreshTokens { get; set; } = null!;
    }
}
