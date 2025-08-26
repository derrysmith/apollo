## apollo

<!-- badges -->

<!-- readme -->
Open-source library for building enterprise .NET and ASP.NET Core software solutions. Provides fundamental infrastructure,
orthogonal concerns, and core models for building applications in a clean and domain-driven style.

## Getting Started

### Installation

### Usage

### Usage

#### Entities

```csharp
using Apollo.Extensions.Core.Entities;

public class User : AggregateRoot<UserId>
{
	// implement user aggregate
}

[EntityKey(Prefix = "usr_")]
public readonly partial record struct UserId;
```

#### Features

```csharp
using Apollo.Extensions.Core.Features;
using Apollo.Extensions.Core.Messages;

public record UserCreated : IIntegrationEvent;

public static class CreateUser
{
	public record Request : IFeatureRequest<Response>;

	public record Response(string UserId);

	public class Handler : IFeatureRequeestHandler<Request, Response>
	{
		public (Response, UserCreated) Handle(Request request, IUserRepository repository)
		{
			// create user entity
			var args = request.MapTo<CreateUserArgs>();
			var user = User.Create(args);

			// append user entity
			repository.Append(user);

			// create user events
			var userCreated = new UserCreated();

			return (new Response(user.Id.ToString()), userCreated);
		}
	}
}
```