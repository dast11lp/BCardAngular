using System.ComponentModel.DataAnnotations;

namespace FECreditCard.Models
{
  public class CreditCard
  {
    public int Id { get; set; }

    [Required]
    public string Holder { get; set; }

    [Required]
    [RegularExpression(@"[0-9]{16}")]
    public string cardNumber { get; set; }

    [Required]
    [RegularExpression(@"\d{2}\/\d{2}")]
    public string DueDate { get; set; }

    [Required]
    [RegularExpression(@"[0-9]{3}")]
    public string cvv { get; set; }

    public BankAccount? BankAccount { get; set; }
    }
}
