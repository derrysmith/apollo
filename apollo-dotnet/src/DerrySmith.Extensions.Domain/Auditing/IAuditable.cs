namespace DerrySmith.Extensions.Domain.Auditing;

/// <summary>
/// 
/// </summary>
public interface IAuditable : IWasCreatedAt, IWasCreatedBy, IWasUpdatedAt, IWasUpdatedBy;