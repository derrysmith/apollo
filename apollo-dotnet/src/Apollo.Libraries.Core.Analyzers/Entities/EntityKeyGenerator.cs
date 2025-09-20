using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Apollo.Libraries.Core.Entities;

[Generator]
internal class EntityKeyGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		// generate entity key attribute
		const string entityKeyAttributeFileName = "Apollo.Libraries.Core.Entities.EntityKeyAttribute.g.cs";
		context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
			entityKeyAttributeFileName,
			SourceText.From(EntityKeyGeneratorHelpers.EntityKeyAttributeSourceCode, Encoding.UTF8)));

		// generate entity key interface
		const string entityKeyInterfaceFileName = "Apollo.Libraries.Core.Entities.IEntityKey.g.cs";
		context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
			entityKeyInterfaceFileName,
			SourceText.From(EntityKeyGeneratorHelpers.EntityKeyInterfaceSourceCode, Encoding.UTF8)));

		// generate entity key
		var entityKeys = context.SyntaxProvider.ForAttributeWithMetadataName(
			EntityKeyGeneratorHelpers.EntityKeyAttributeFullName, predicate: CanTransform, transform: Transform);

		context.RegisterSourceOutput(entityKeys, Generate);
	}
		
	private static bool CanTransform(SyntaxNode _, CancellationToken ct)
	{
		return true;
	}
	
	private static EntityKey? Transform(GeneratorAttributeSyntaxContext ctx, CancellationToken ct)
	{
		// exit method early if we can't get the symbol
		if (ctx.SemanticModel.GetDeclaredSymbol(ctx.TargetNode, ct) is not INamedTypeSymbol symbol) return null;

		var typeName      = symbol.Name;
		var typeNamespace = symbol.ContainingNamespace.ToString();

		var attribute = ctx.Attributes.First(data =>
			data.AttributeClass?.Name == EntityKeyGeneratorHelpers.EntityKeyAttributeTypeName);
		
		var prefix = attribute.NamedArguments.FirstOrDefault(kvp =>
			kvp.Key == "Prefix").Value.Value?.ToString() ?? string.Empty;
		var suffix = attribute.NamedArguments.FirstOrDefault(kvp =>
			kvp.Key == "Suffix").Value.Value?.ToString() ?? string.Empty;
		// var valueType = (EntityKeyValueType)(attribute.NamedArguments.FirstOrDefault(kvp =>
		// 	kvp.Key == nameof(EntityKeyAttribute.ValueType)).Value.Value ?? EntityKeyValueType.Ulid);

		return new EntityKey(typeNamespace, typeName, prefix, suffix);
	}
	
	private static void Generate(SourceProductionContext spc, EntityKey? entityKey)
	{
		// do not generate any source code if model is null
		if (entityKey is null) return;
		
		// source code
		var source = $@"
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apollo.Libraries.Core.Entities;

namespace {entityKey.TypeNamespace}
{{
	public readonly partial record struct {entityKey.TypeName} : IEntityKey<{entityKey.TypeName}>
	{{
		private const string Prefix = ""{entityKey.Prefix}"";
		private const string Suffix = ""{entityKey.Suffix}"";

		private readonly Ulid _value = default;

		private {entityKey.TypeName}(Ulid value) => _value = value;

		public static {entityKey.TypeName} New() => new {entityKey.TypeName}(Ulid.NewUlid());

		public static {entityKey.TypeName} Parse(string value)
		{{
			if (TryParse(value, out var entityKey))
				return entityKey;

			var error = $""Cannot parse '{{value}}' into {entityKey.TypeName}."";
			throw new ArgumentException("""", nameof(value));
		}}

		public static bool TryParse(string value, out {entityKey.TypeName} entityKey)
		{{
			var entityKeyValue = EntityKeyExtensions.ExtractEntityKeyValue(value, Prefix, Suffix);

			if (Ulid.TryParse(entityKeyValue, out var ulid))
			{{
				entityKey = new {entityKey.TypeName}(ulid);
				return true;
			}}

			if (Guid.TryParse(entityKeyValue, out var guid))
			{{
				entityKey = new {entityKey.TypeName}(new Ulid(guid));
				return true;
			}}

			entityKey = default;
			return false;
		}}

		public Guid ToGuid() => _value.ToGuid();

		public override string ToString() => $""{{Prefix}}{{_value}}{{Suffix}}"";
	}}
}}
";

		spc.AddSource(entityKey.FileName, SourceText.From(source, Encoding.UTF8));
	}
}