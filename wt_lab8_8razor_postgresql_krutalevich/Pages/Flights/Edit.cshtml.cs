using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class EditModel : PageModel
{
    [BindProperty]
    public Flight Flight { get; set; } = new();
    public IActionResult OnGet(int id)
    {
        var flight = FlightStore.Flights.FirstOrDefault(f => f.Id == id);
        if (flight == null)
            return NotFound();

        Flight = flight;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existing = FlightStore.Flights.FirstOrDefault(f => f.Id == Flight.Id);
        if (existing == null)
            return NotFound();

        existing.FlightNumber = Flight.FlightNumber;
        existing.Departure = Flight.Departure;
        existing.Arrival = Flight.Arrival;
        existing.Price = Flight.Price;
        existing.IsAvailable = Flight.IsAvailable;

        return RedirectToPage("./Index");
    }
}