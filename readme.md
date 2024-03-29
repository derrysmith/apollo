﻿# apollo

```
> derrysmith/apollo
	> client
		> apollo-sdk
		> apollo-sdk-dotnet
		> apollo-sdk-nodejs
		> apollo-web
		> apollo-web-admin
	> server
		> apollo-api
		> apollo-api-calendar
		> apollo-api-contacts
			> src
				> Apollo.Contacts.Api
				> Apollo.Contacts.Api.GraphQL
				
				> Apollo.Contacts.Core
					> Entities
						> Models
							- Address
							- AddressType
							- Email
							- EmailType
							- Phone
							- PhoneType
						- Contact
					> Features
						- CreateContact
						- DeleteContact
						- ExportContacts
						- FilterContacts
						- GetContact
						- ImportContacts
						- SearchContacts
						- UpdateContact
					> Handlers
						- OnAccountCreated
					> Services
						- IContactContext
						- IContactFactory
						- IContactRepository
						- IContactRepositoryProvider
					> UseCases
				> Apollo.Contacts.Data
					> EF
					> Sqlite
					> EF/Redis
					> EF/Sqlite
					> EF/SqlServer
		> apollo-api-identity
	> shared
```