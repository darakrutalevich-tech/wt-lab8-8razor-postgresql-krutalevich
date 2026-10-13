using System.ComponentModel.DataAnnotations;
namespace wt_lab8_8razor_postgresql_krutalevich.Models;

public class Flight
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите номер рейса")]
    [StringLength(20)]
    [Display(Name = "Номер рейса")]
    public string FlightNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите город вылета")]
    [Display(Name = "Город вылета")]
    public string Departure { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите город прилёта")]
    [Display(Name = "Город прилёта")]
    public string Arrival { get; set; } = string.Empty;

    [Range(1, 1000000, ErrorMessage = "Цена должна быть положительной")]
    [Display(Name = "Цена, руб.")]
    public decimal Price { get; set; }

    [Display(Name = "Доступен")]
    public bool IsAvailable { get; set; }
}