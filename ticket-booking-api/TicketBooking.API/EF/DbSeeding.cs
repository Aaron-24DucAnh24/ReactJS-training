using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TicketBooking.API.Models;

namespace TicketBooking.API.EF
{
  public class ApplicationDbContextSeeding
  {
    public static void Run(ref ModelBuilder modelBuilder)
    {
      StreamReader categoryReader = new("./EF/SeedingData/Category.json");
      StreamReader eventReader = new("./EF/SeedingData/Event.json");
      StreamReader seatReader = new("./EF/SeedingData/Seat.json");
      StreamReader eventCategoryReader = new("./EF/SeedingData/EventCategory.json");
      StreamReader seatEventReader = new("./EF/SeedingData/SeatEvent.json");

      string categoriesJson = categoryReader.ReadToEnd();
      string eventJson = eventReader.ReadToEnd();
      string seatJson = seatReader.ReadToEnd();
      string eventCategoryJson = eventCategoryReader.ReadToEnd();
      string seatEventJson = seatEventReader.ReadToEnd();

      var categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);
      var events = JsonSerializer.Deserialize<List<Event>>(eventJson);
      var seats = JsonSerializer.Deserialize<List<Seat>>(seatJson);
      var eventCategories = JsonSerializer.Deserialize<List<EventCategory>>(eventCategoryJson);
      var seatEvents = JsonSerializer.Deserialize<List<SeatEvent>>(seatEventJson);

      foreach(var category in categories)
      {
        modelBuilder.Entity<Category>().HasData(category);
      }

      foreach(var e in events)
      {
        modelBuilder.Entity<Event>().HasData(e);
      }

      foreach(var seat in seats)
      {
        modelBuilder.Entity<Seat>().HasData(seat);
      }

      foreach (var seatEvent in seatEvents)
      {
        modelBuilder.Entity<SeatEvent>().HasData(seatEvent);
      }

      foreach (var eventCategory in eventCategories)
      {
        modelBuilder.Entity<EventCategory>().HasData(eventCategory);
      }
    }
  }
}