using System.ComponentModel.DataAnnotations; // To use [Required] attribute and [StringLenght]

namespace Northwind.EntityModels;

public class  Category
{
    public int CategoryId { get; set; }

    [Required] // This attribute indicates that the CategoryName property is required and cannot be null or empty.
    [StringLength(15)]
    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }
}
