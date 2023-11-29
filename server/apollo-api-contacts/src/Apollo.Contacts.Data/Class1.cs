using Apollo.Contacts.Core.Entities;
using Apollo.Contacts.Core.Services;
using Apollo.Contacts.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Contacts.Data.Database
{
	using Apollo.Contacts.Core.Entities;
	using Microsoft.EntityFrameworkCore;

	public static class ContactsDbContextExtensions
	{
		public static void InitializeDatabase(this ContactsDbContext context)
		{
			if (context.Database.EnsureCreated())
			{
				var rockyBalboa = new Contact
				{
					FName = "Rocky",
					LName = "Balboa",
					Alias = "The Italian Stallion"
				};

				var apolloCreed = new Contact
				{
					FName = "Apollo",
					LName = "Creed"
				};

				context.Contacts.Add(rockyBalboa);
				context.Contacts.Add(apolloCreed);

				context.SaveChanges();
			}
		}
	}

	public class ContactsDbContext : DbContext
	{
		public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
			: base(options)
		{
		}

		public DbSet<Contact> Contacts { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// [dbo].contact
			modelBuilder.Entity<Contact>()
				.ToTable("contact", "dbo")
				.HasKey(c => c.Id).HasName("pk_contact");
		}
	}
}

namespace Apollo.Contacts.Data.Services
{
	public class ContactEntityFxCoreRepository : IContactRepository, IAsyncDisposable
	{
		private readonly ContactsDbContext _context;

		public ContactEntityFxCoreRepository(IDbContextFactory<ContactsDbContext> factory)
		{
			_context = factory.CreateDbContext();
		}

		public async Task<Contact> GetAsync(Guid id, CancellationToken ct = default)
		{
			var contact = await _context.Contacts.FindAsync(new object?[] { id }, cancellationToken: ct);

			if (contact == null)
				throw new ApplicationException("could not find contact");

			return contact;
		}

		public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}
	}
}