namespace DerrySmith.Apollo.Extensions.Core.Entities;

public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot;