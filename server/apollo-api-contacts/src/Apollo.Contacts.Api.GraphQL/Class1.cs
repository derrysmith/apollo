using Apollo.Contacts.Core.Entities;
using Apollo.Contacts.Core.Services;
using Apollo.Contacts.Data.Database;

namespace Apollo.Contacts.Api.GraphQL;

public class RootQuery
{
	public async Task<Contact?> GetContact(Guid id, [Service] IContactRepository repository)
	{
		return await repository.GetAsync(id);
	}

	public IQueryable<Contact> GetContacts(ContactsDbContext context)
	{
		return context.Contacts;
	}
}