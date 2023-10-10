namespace DS.Apollo.Core.ValueProviders;

public interface ISequentialValueProvider<out T>
{
	T Next();
}