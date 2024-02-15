using System.ComponentModel.DataAnnotations;

namespace FECreditCard.Models
{
  public class CreditCard
  {
    public int Id { get; set; }

    [Required]
    public string Holder { get; set; }

    [Required]
    public string cardNumber { get; set; }

    [Required]
    public string DueDate { get; set; }

    [Required]
    public string cvv { get; set; }
  }
}
