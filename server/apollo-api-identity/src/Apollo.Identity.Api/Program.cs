using System.Reflection;
using Apollo.Identity.Core.Application;
using Apollo.Identity.Core.Application.AppUsers.Services;
using Apollo.Identity.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Entities;
using Apollo.Identity.Core.Domain.AppUsers.Services;
using Apollo.Identity.Core.Infrastructure;
using Apollo.Identity.Core.Infrastructure.Database;
using Apollo.Identity.Core.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region - configure container

var identityAssemblies = new Assembly[]
{
	IdentityDomain.Assembly,
	IdentityApplication.Assembly,
	IdentityInfrastructure.Assembly
};

builder.Services.AddMediatR(x => { x.RegisterServicesFromAssemblies(identityAssemblies); });

builder.Services.AddValidatorsFromAssemblies(identityAssemblies);

builder.Services.AddScoped<IAppUserFactory, AppUser.Factory>();
builder.Services.AddScoped<IAppUserContext, AppUserUnitOfWork>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();

builder.Services.AddDbContext<IdentityDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("apollo.identity"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region configure http request pipeline

if (app.Environment.IsDevelopment())
{
	using (var scope = app.Services.CreateScope())
	{
		// on application startup, run migration scripts (FOR DEVELOPMENT ONLY)
		var context = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
		context.Database.Migrate();
	}
	
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

#endregion

app.Run();