using System.ComponentModel.DataAnnotations;

namespace Northwind.EntityModels;

public class Customer
{
    [Key]
    [StringLength(5)]
    public string CustomerId { get; set; } = null!; 

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string City { get; set; } = null!;
}
