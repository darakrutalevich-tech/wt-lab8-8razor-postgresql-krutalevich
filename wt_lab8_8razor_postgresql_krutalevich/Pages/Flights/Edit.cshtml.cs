using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Flight Flight { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight == null)
            return NotFound();

        Flight = flight;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var existing = await _context.Flights.FindAsync(Flight.Id);
        if (existing == null)
            return NotFound();

        existing.FlightNumber = Flight.FlightNumber;
        existing.Departure = Flight.Departure;
        existing.Arrival = Flight.Arrival;
        existing.Price = Flight.Price;
        existing.IsAvailable = Flight.IsAvailable;

        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}