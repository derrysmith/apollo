using Legenderry.Apollo.Extensions.Core.Entities;

namespace Legenderry.Apollo.Extensions.Core.Tests.Entities;

[EntityKey(Prefix = "mid_", Suffix = "_key")]
public readonly partial record struct UnitTestId;