using Apollo.Api.Identity;
using Apollo.Core.Application;
using Apollo.Core.Application.Identity.Features;
using Apollo.Core.Domain;
using Apollo.Core.Domain.Identity.Entities;
using Apollo.Infrastructure.Data.EF;
using Apollo.Infrastructure.Data.EF.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Api;

public static class ApolloApi
{
	public static System.Reflection.Assembly Assembly => typeof(ApolloApi).Assembly;

	public static IServiceCollection AddApollo(
		this IServiceCollection services, IConfigurationManager configuration, IWebHostEnvironment environment)
	{
		var assemblies = new[]
		{
			ApolloApi.Assembly,
			ApolloCoreApplication.Assembly,
			ApolloCoreDomain.Assembly,
			ApolloInfraDataEntityFx.Assembly,
		};

		// Add services to the container.
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		// Apollo.Core.Domain

		// Apollo Repositories
		services.AddTransient<IUserProfileRepository, UserProfileRepository>();

		// MassTransit

		// MediatR
		services.AddMediatR(config => { config.RegisterServicesFromAssemblies(assemblies); });

		// Entity Framework
		var apolloConnectionStringKey = "apollo";
		var apolloConnectionString    = configuration.GetConnectionString(apolloConnectionStringKey);

		services.AddDbContext<ApolloDbContext>(config =>
		{
			if (environment.IsDevelopment())
				config.UseInMemoryDatabase(apolloConnectionStringKey);

			if (environment.IsProduction())
				config.UseNpgsql(apolloConnectionString);
		});

		return services;
	}

	public static WebApplication UseApollo(this WebApplication application)
	{
		// configure the http request pipeline
		if (application.Environment.IsDevelopment())
		{
			application.UseSwagger();
			application.UseSwaggerUI();
		}

		// configure database migrations
		using (var scope = application.Services.CreateScope())
		{
			var context = scope.ServiceProvider.GetRequiredService<ApolloDbContext>();
			
			if (application.Environment.IsDevelopment())
				context.Database.EnsureCreated();

			if (application.Environment.IsProduction())
				context.Database.Migrate();
		}

		application.UseHttpsRedirection();

		// configure routing
		application.MapIdentityRoutes();

		return application;
	}
}
