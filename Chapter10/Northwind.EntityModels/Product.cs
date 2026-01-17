using System.ComponentModel.DataAnnotations.Schema; // To use [Column]
using System.ComponentModel.DataAnnotations; // To use [Required]

namespace Northwind.EntityModels;

public class Product
{
    public int ProductId { get; set; } // Primary key

    [Required]
    [StringLength(40)] // Max length of 40 characters
    public string ProductName { get; set; } = null!; // Not null

    // Property name is different from the column name
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }

    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    // Foreign key property 
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!; // Navigation property to related Category
}
