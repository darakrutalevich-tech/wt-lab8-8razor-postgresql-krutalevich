using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public List<Flight> Flights { get; set; } = new();

    public async Task OnGetAsync()
    {
        var query = _context.Flights.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(f =>
                f.FlightNumber.Contains(Search) ||
                f.Departure.Contains(Search) ||
                f.Arrival.Contains(Search));
        }

        Flights = await query
            .OrderBy(f => f.Id)
            .ToListAsync();
    }
}