## apollo

```
> derrysmith/apollo
	> apollo-dotnet
		> src
			> DerrySmith.Apollo.Extensions.Core
			> DerrySmith.Apollo.Extensions.Core.Abstractions
			> DerrySmith.Apollo.Extensions.Core.Analyzers
		> test
			> DerrySmith.Apollo.Extensions.Core.Tests
		- apollo-dotnet.slnx
	> apollo-nodejs
```

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