namespace OTBHolidaySearch1.Flights
{
    public class Flight
    {
        public int    Id { get; set; }
        public string? Airline { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public int? Price { get; set; }
        public string? Departure_date { get; set; }
    }
}
