using System.ComponentModel.DataAnnotations;

namespace F1API.Models
{
  public class Driver
  {
    public int DriverId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name {get; set; }
    [Required]
    [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
    public int Age { get; set; }
    [Required]
    [StringLength(50)]
    public string Team { get; set; }
  }
}