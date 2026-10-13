using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class CreateModel : PageModel
{
    [BindProperty]
    public Flight Flight { get; set; } = new();

    // GET: /Flights/Create
    public void OnGet()
    {
    }

    // POST: /Flights/Create
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Flight.Id = FlightStore.NextId();
        FlightStore.Flights.Add(Flight);
        return RedirectToPage("./Index");
    }
}