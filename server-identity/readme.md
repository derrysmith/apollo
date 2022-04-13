# apollo: server-identity

```
> derrysmith/apollo
	> server-identity
		> src
			> Apollo.Identity.Core
				> Users
			> Apollo.Identity.Core.Users
				> Entities
				> Features
				> Handlers
				> Services
				- User
				- UserKey

			> Apollo.Identity.Kernel.Dapr
			> Apollo.Identity.Kernel.Data
			
			> Apollo.Identity.Worker.Api
				> Hooks
					> Models
					> Routes
						- PostUserRegistrationRoute
					- HookController
						+ Task<IActionResult> HandleAsync(PostUserRegistration.Payload payload)
				> Users
					- UserController
```