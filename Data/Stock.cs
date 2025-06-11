using System.ComponentModel.DataAnnotations;

namespace StockTracker.Data;
public class Stock
{

  [Key]
  public string? ticker { get; set; }

  public string? userId { get; set; }

}