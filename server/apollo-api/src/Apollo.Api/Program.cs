using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region - configure configuration

builder.Configuration.AddJsonFile("ocelot.json", false, true);

#endregion

#region - configure container

builder.Services.AddControllers();
builder.Services.AddOcelot(builder.Configuration)
	.AddCacheManager(x => x.WithDictionaryHandle());

#endregion

var app = builder.Build();

#region configure http request pipeline

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();

#endregion

app.Run();