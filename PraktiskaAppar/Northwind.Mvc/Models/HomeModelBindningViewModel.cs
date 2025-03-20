namespace Northwind.Mvc.Models
{
    public record HomeModelBindningViewModel(
        Thing thing,
        bool HasErrors,
        IEnumerable<string> ValidationErrors
    );
    
    
}
