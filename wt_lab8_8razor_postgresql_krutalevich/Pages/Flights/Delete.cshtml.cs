using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class DeleteModel : PageModel
{
    public Flight? Flight { get; set; }

    public IActionResult OnGet(int id)
    {
        Flight = FlightStore.Flights.FirstOrDefault(f => f.Id == id);
        if (Flight == null)
            return NotFound();

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        var flight = FlightStore.Flights.FirstOrDefault(f => f.Id == id);
        if (flight == null)
            return NotFound();

        FlightStore.Flights.Remove(flight);
        return RedirectToPage("./Index");
    }
}