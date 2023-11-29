using Apollo.Contacts.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Contacts.Api;

public static class ContactsApiRegistration
{
	public static IServiceCollection AddContactsDatabase(this IServiceCollection services)
	{
		services.AddPooledDbContextFactory<ContactsDbContext>((sp, options) =>
		{
			options.UseSqlite("Data Source=contacts.db");
		});
		
		services.AddDbContext<ContactsDbContext>();
		
		return services;
	}

	public static void UseContactsDatabase(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
		
		var context = scope.ServiceProvider.GetRequiredService<ContactsDbContext>();
		context.InitializeDatabase();
	}
}