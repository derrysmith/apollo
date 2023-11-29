using Apollo.Identity.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apollo.Identity.Core.Infrastructure.Entities;

public class AppUserEntityTypeConfiguration : IEntityTypeConfiguration<AppUser>
{
	public void Configure(EntityTypeBuilder<AppUser> builder)
	{
		// [dbo].app_user
		builder.ToTable("appuser", "dbo");

		// primary key
		builder.HasKey(usr => usr.Id);

		// columns
		builder.Property(usr => usr.Id).HasColumnName("id")
			.HasConversion(id => id.ToString(), sql => new AppUserKey(sql))
			.HasMaxLength(250).ValueGeneratedNever().IsRequired();

		builder.Property(usr => usr.FName).HasColumnName("fname")
			.HasMaxLength(125).IsRequired();

		builder.Property(usr => usr.LName).HasColumnName("lname")
			.HasMaxLength(125).IsRequired();

		builder.Property(usr => usr.AuthProviderName).HasColumnName("auth_provider_name")
			.HasMaxLength(125).IsRequired();

		builder.Property(usr => usr.AuthProviderType).HasColumnName("auth_provider_type")
			.HasMaxLength(125).IsRequired();

		builder.Property(usr => usr.AuthProviderUserId).HasColumnName("auth_provider_user_id")
			.HasMaxLength(250).IsRequired();

		builder.Property(usr => usr.AuthProviderUserName).HasColumnName("auth_provider_user_name")
			.HasMaxLength(250).IsRequired();

		builder.OwnsOne(usr => usr.Email, x =>
		{
			x.Property(e => e.Address).HasColumnName("email").HasMaxLength(250);
			x.Property(e => e.IsVerified).HasColumnName("email_verified");
		});

		builder.OwnsOne(usr => usr.Phone, x =>
		{
			x.Property(p => p.Number).HasColumnName("phone").HasMaxLength(25);
			x.Property(p => p.IsVerified).HasColumnName("phone_verified");
		});

		// shadow properties (not in model but in db)
		builder.Property<DateTimeOffset>("created_at")
			.ValueGeneratedOnAdd().IsRequired();
		
		builder.Property<DateTimeOffset>("updated_at")
			.ValueGeneratedOnAddOrUpdate().IsRequired();
		
		builder.Property<byte[]>("row_version")
			.ValueGeneratedOnAddOrUpdate().IsConcurrencyToken().IsRequired();
	}
}