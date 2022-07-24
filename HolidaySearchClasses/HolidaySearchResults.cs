namespace OTBHolidaySearch1.HolidaySearch
{
    public class HolidaySearchResult
    {
        public int      Id { get; set; }
        public int      Total_Price { get; set; }
        public int      Flight_Id { get; set; }
        public string?  Flight_From { get; set; }
        public string?  Flight_To { get; set; }
        public string?  Flight_Departure_Date { get; set; }
        public int      Flight_Price { get; set; }
        public int      Hotel_Id { get; set; }
        public string?  Hotel_Name { get; set; }
        public int      Hotel_Price { get; set; }
        public int      Hotel_Nights { get; set; }
    }
}