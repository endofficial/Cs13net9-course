using System.ComponentModel.DataAnnotations; // To use [Required] attribute and [StringLenght]
using System.ComponentModel.DataAnnotations.Schema; // To use [Column] attribute

namespace Northwind.EntityModels;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }

    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    [Column(TypeName = "money")]
    public decimal? UnitPrice { get; set; }

}
