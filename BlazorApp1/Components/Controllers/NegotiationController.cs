using BlazorApp1.Components.Class;
using BlazorApp1.Components.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class NegotiationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public NegotiationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNegotiation([FromBody] Negotiation negotiation)
    {
        // Zabezpieczenie przed próbą ustawienia Id i EndDate przez użytkownika
        negotiation.Id = 0; // lub po prostu tego nie ustawiaj
        negotiation.EndDate = DateTime.Now.AddDays(7);

        _context.Negotiations.Add(negotiation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetNegotiationById), new { id = negotiation.Id }, negotiation);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Negotiation>>> GetNegotiationById(int id)
    {
        List<Negotiation> negotiation = await _context.Negotiations.Where(n => n.ProductId == id).ToListAsync();

        if (negotiation == null)
        {
            return NotFound();
        }

        return negotiation;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var test = new Negotiation
        {
            Id = 1,
            ProductId = 123,
            Price = 100.00m,
            EndDate = DateTime.UtcNow.AddDays(7),
            isAccepted = false
        };

        return Ok(test);
    }
}
