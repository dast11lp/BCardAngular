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

    public CardController (ApplicationDbContext context)
    {
      this._context = context;
    }

    // GET: api/<CardController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var cardList = await _context.CreditCards.ToListAsync();
        return Ok(cardList);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    /*
    // GET api/<CardController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }*/

    // POST api/<CardController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreditCard creditCard)
    {
      System.Diagnostics.Debug.WriteLine("holaaa");

      System.Diagnostics.Debug.WriteLine("holaaa");
      try
      {
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
    public async Task<IActionResult> Put(int id, [FromBody]CreditCard creditCard)
    {
      try
      {
        if(id != creditCard.Id)
        {
          return NotFound();
        }

        _context.Update(creditCard);
        await _context.SaveChangesAsync();
        return Ok(new { message = "La tarjeta fue utilizada con exito"});
      }catch (Exception ex)
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
