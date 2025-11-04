using System.ComponentModel.DataAnnotations;

namespace AspireSample.ApiService.Data;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    public int StockQuantity { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
}