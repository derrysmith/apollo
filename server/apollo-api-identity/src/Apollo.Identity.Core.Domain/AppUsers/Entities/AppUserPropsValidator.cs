using FluentValidation;

namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

public class AppUserPropsValidator : AbstractValidator<AppUserProps>
{
	public AppUserPropsValidator()
	{
		this.RuleFor(r => r.FName).NotEmpty();
		this.RuleFor(r => r.LName).NotEmpty();
		this.RuleFor(r => r.AuthProviderName).NotEmpty();
		this.RuleFor(r => r.AuthProviderType).NotEmpty();
		this.RuleFor(r => r.AuthProviderUserId).NotEmpty();
		this.RuleFor(r => r.AuthProviderUserName).NotEmpty();
	}
}