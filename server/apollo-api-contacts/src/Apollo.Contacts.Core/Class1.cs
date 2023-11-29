namespace Apollo.Contacts.Core.Entities
{
	using System.Text.Json.Serialization;
	
	public class Contact
	{
		[JsonPropertyName("id")]
		public Guid Id { get; private set; } = default!;

		[JsonPropertyName("fname")]
		public string? FName { get; set; }
		
		[JsonPropertyName("mname")]
		public string? MName { get; set; }
		
		[JsonPropertyName("lname")]
		public string? LName { get; set; }
		
		[JsonPropertyName("alias")]
		public string? Alias { get; set; }

		
		[JsonPropertyName("prefix")]
		public string? Prefix { get; set; }
		
		[JsonPropertyName("suffix")]
		public string? Suffix { get; set; }
	}
}

namespace Apollo.Contacts.Core.Entities.Models
{
	public record Address
	{
	}

	public record AddressType(string Label)
	{
		public static readonly AddressType Home = new(nameof(Home));
		public static readonly AddressType Work = new(nameof(Work));

		public static IEnumerable<AddressType> GetAddressTypes()
		{
			yield return Home;
			yield return Work;
		}
	}

	public record Email
	{
	}

	public record EmailType(string Label);

	public static class EmailTypes
	{
		public static readonly EmailType Personal = new(nameof(Personal));
		public static readonly EmailType Business = new(nameof(Business));
		
		public static IEnumerable<EmailType> GetEmailTypes()
		{
			// why complicate things
			yield return Personal;
			yield return Business;
		}
	}

	public record Event
	{
	}

	public record EventType(string Label);

	public static class EventTypes
	{
		public static readonly EventType Birthday = new(nameof(Birthday));
		public static readonly EventType Anniversary = new(nameof(Anniversary));

		public static IEnumerable<EventType> GetEventTypes()
		{
			// why complicate things
			yield return Birthday;
			yield return Anniversary;
		}
	}

	public record Phone
	{
	}

	public record PhoneType
	{
		// home, work, cell, fax
	}

	public record Relationship
	{
	}

	public record RelationshipType
	{
		// partner, sibling, parent, child
	}
}

namespace Apollo.Contacts.Core.Features
{
	public static class GetContact
	{
	}

	public static class GetContacts
	{
	}

	public static class CreateContact
	{
	}

	public static class DeleteContact
	{
	}

	public static class UpdateContact
	{
	}

	public static class ExportContacts
	{
	}

	public static class ImportContacts
	{
	}

	public static class FilterContacts
	{
	}

	public static class SearchContacts
	{
	}
}

namespace Apollo.Contacts.Core.Handlers
{
}

namespace Apollo.Contacts.Core.Services
{
	using Apollo.Contacts.Core.Entities;

	public interface IContactContext
	{
		IContactRepository Contacts { get; }
		Task CommitAsync(CancellationToken ct = default);
	}

	public interface IContactFactory
	{
	}

	public interface IContactRepository
	{
		Task<Contact> GetAsync(Guid id, CancellationToken ct = default);
	}

	public interface IContactRepositoryProvider
	{
		IContactRepository GetOrCreate();
	}
}