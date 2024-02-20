using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FECreditCard.Models;
using FECreditCard;

namespace FECreditCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBankAccountToCard(int cardId, BankAccount bankAccount)
        {
            try
            {
                var creditCard = await _context.CreditCards.FindAsync(cardId);

                if (creditCard == null)
                {
                    return NotFound();
                }

                bankAccount.CreditCardId = cardId;
                _context.BankAccount.Add(bankAccount);
                await _context.SaveChangesAsync();

                return Ok(bankAccount);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccount(int id)
        {
            try
            {   
                var banckAccount = await _context.BankAccount.FindAsync(id);
                if (banckAccount == null)
                {
                    return NotFound();
                }

                return Ok(banckAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}