namespace Apollo.Entities;

/// <summary>
/// Represents the entity that is the root of the domain aggregate.
/// </summary>
/// 
/// <typeparam name="TAggRootKey">
/// The type of the entity's unique identifier.
/// </typeparam>
public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot;
