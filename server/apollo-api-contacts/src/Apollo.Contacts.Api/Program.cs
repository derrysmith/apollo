using Apollo.Contacts.Api;
using Apollo.Contacts.Api.GraphQL;
using Apollo.Contacts.Core.Services;
using Apollo.Contacts.Data.Database;
using Apollo.Contacts.Data.Services;
using HotChocolate;

var builder = WebApplication.CreateBuilder(args);

#region - configure dependency injection container

// configure database
builder.Services.AddContactsDatabase();

builder.Services.AddTransient<IContactRepository, ContactEntityFxCoreRepository>();

// configure graphql
builder.Services.AddGraphQLServer()
	.RegisterDbContext<ContactsDbContext>()
	.AddQueryType<RootQuery>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region configure http request pipeline

// initialize database
app.UseContactsDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();

#endregion

app.Run();