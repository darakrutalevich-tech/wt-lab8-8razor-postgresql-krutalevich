using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class DetailsModel : PageModel
{
    public Flight? Flight { get; set; }
    public IActionResult OnGet(int id)
    {
        Flight = FlightStore.Flights.FirstOrDefault(f => f.Id == id);

        if (Flight == null)
            return NotFound();   // HTTP 404

        return Page();
    }
}