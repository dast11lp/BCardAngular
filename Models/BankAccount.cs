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
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Balance { get; set; }

        public int? CreditCardId { get; set; }

        [JsonIgnore]
        public CreditCard? CreditCard { get; set; }

        public BankAccount()
        {
            AccountNumber = Guid.NewGuid().ToString();
        }
    }
}

