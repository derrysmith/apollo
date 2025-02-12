using Apollo.Core.Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apollo.Infrastructure.Data.EF.Identity;

public class UserProfileConfiguration() : EntityFxTypeConfiguration<UserProfile, UserProfileId>(IdentityConfiguration.Schema)
{
	protected override void ConfigureProperties(EntityTypeBuilder<UserProfile> builder)
	{
		builder.Property(x => x.DisplayName).HasMaxLength(256).IsRequired();
		builder.Property(x => x.Description).HasMaxLength(512);
		
		builder.OwnsOne(x => x.Email, b =>
		{
			b.Property(a => a.Address).HasMaxLength(256);
			b.Property(a => a.IsVerified).HasDefaultValue(false);
		});
		
		builder.OwnsOne(x => x.Phone, b =>
		{
			b.Property(a => a.Number).HasMaxLength(64);
			b.Property(a => a.IsVerified).HasDefaultValue(false);
		});

		builder.OwnsOne(x => x.Login, b =>
		{
			b.Property(a => a.AuthIssuer).HasMaxLength(128);
			b.Property(a => a.AuthUserId).HasMaxLength(256);
		});
	}
}