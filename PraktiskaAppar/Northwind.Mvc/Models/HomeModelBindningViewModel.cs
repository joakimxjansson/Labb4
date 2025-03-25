namespace Northwind.Mvc.Models
{
    public record HomeModelBindningViewModel(Thing Thing, bool HasErrors,
        IEnumerable<string> ValidationErrors);



}
