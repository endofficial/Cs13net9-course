using System.ComponentModel.DataAnnotations.Schema; // To use [Column]

namespace Northwind.EntityModels;

public class Category
{
    // These properties map to columns in the Categories table
    public int CategoryId { get; set; } // Primary key
    public string CategoryName { get; set; } = null!; // Not null

    [Column(TypeName = "ntext")]
    public string? Description { get; set; } // Nullable

    // Defines a navigation property for related rows.
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); // ogni volta che hai una Categoria, puoi facilmente raggiungere tutti i Prodotti collegati ad essa.
}
