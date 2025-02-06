using BECase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BECase.Data.Mapping
{
    public class JwtRefreshTokenMap : IEntityTypeConfiguration<JwtRefreshToken>
    {
        public void Configure(EntityTypeBuilder<JwtRefreshToken> builder)
        {
            builder.ToTable("JwtRefreshTokens");

            builder.HasKey(x => x.Id);
        }
    }
}
