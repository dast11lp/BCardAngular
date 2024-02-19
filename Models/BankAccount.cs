using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FECreditCard.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public int? CreditCardId { get; set; }

        [JsonIgnore]
        public CreditCard? CreditCard { get; set; }
    }
}
