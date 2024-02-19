using FECreditCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FECreditCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/<CardController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //var cardList = await _context.CreditCards.ToListAsync();
                //var cardList = await _context.CreditCards.Include(c => c.BankAccount).ToListAsync();
                var cardList = await _context.CreditCards
                   .Select(c => new
                   {
                       c.Id,
                       c.Holder,
                       c.cardNumber,
                       c.DueDate,
                       c.cvv,
                       BankAccountId = c.BankAccount != null ? c.BankAccount.Id : (int?)null
                   })
                   .ToListAsync();
                return Ok(cardList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditCard creditCard)
        {
            try
            {
                var bankAccount = new BankAccount
                {
                    Balance = 1000.77m,
                    CreditCardId = creditCard.Id,
                    CreditCard = creditCard
                };

                creditCard.BankAccount = bankAccount;


                _context.CreditCards.Add(creditCard);

                await _context.SaveChangesAsync();
                return Ok(creditCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreditCard creditCard)
        {
            try
            {
                if (id != creditCard.Id)
                {
                    return NotFound();
                }

                _context.Update(creditCard);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarjeta fue utilizada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var creditCard = await _context.CreditCards.FindAsync(id);
                if (creditCard == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.CreditCards.Remove(creditCard);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "La tarjeta ha sido eliminada cion exito" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
