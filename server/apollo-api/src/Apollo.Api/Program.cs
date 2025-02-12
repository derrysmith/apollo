using Apollo.Api;

var builder = WebApplication.CreateBuilder(args);

#region - configure service container


builder.Services.AddApollo(builder.Configuration, builder.Environment);

#endregion

var app = builder.Build();

#region - configure http request pipeline

app.UseApollo();
app.Run();

#endregion
