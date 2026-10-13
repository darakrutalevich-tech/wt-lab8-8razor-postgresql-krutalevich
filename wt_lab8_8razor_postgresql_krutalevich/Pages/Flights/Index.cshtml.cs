using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_krutalevich.Data;
using wt_lab8_8razor_postgresql_krutalevich.Models;

namespace wt_lab8_8razor_postgresql_krutalevich.Pages.Flights;

public class IndexModel : PageModel
{
    public List<Flight> Flights { get; set; } = new();
    public void OnGet()
    {
        Flights = FlightStore.Flights;
    }
}