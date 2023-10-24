using FormulaOne.API.Authentication;
using FormulaOne.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.API.Controllers
{
    [ServiceFilter(typeof(ApikeyAuthenticationFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            this._context = context;
        }

        //[ServiceFilter(typeof(ApikeyAuthenticationFilter))]
        [HttpGet]
        public async Task<IActionResult>GetAllTicket()
        {
            var ticker= await _context.Events.Include(s=>s.Tickets).ToListAsync();

            return Ok(ticker);
        }


        [HttpPut]
        public async Task<IActionResult>UpdateTicket(int eventId)
        {
             var minEvents= await _context.Events.Include(s=> s.Tickets)
                .FirstOrDefaultAsync(s=>s.Id==eventId);

            if (minEvents == null) return NotFound();

            //foreach(var data in minEvents.Tickets)
            //{
            //    data.Price *= 1.3;

            //}

            await _context.Database.BeginTransactionAsync();

            // Using the SQL Query. we can reduce the Query Execution time. 
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"UPDATE Tickets SET Price = Price *1.3, EventDate ={DateTime.UtcNow.AddDays(21)} Where EventId={eventId}");

            minEvents.Location = $"{minEvents.Location} - at {DateTime.UtcNow.Microsecond}";

            await _context.Database.CommitTransactionAsync();
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
