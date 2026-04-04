using System.ComponentModel.DataAnnotations;

namespace Northwind.EntityModels;

public class Order
{
    public int OrderId { get; set; }

    [Required]
    public string ShipName { get; set; } = null!;

    [Required]
    public string ShipCity { get; set; } = null!;
}
