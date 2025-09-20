namespace Apollo.Libraries.Core.Entities;

public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot;