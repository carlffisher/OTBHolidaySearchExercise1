using OTBHolidaySearch1.Flights;
using OTBHolidaySearch1.HolidaySearch;
using OTBHolidaySearch1.Hotels;

namespace OTBHolidaySearch1.HolidaySearchClasses
{
    public class ExecuteHolidayQuery
    {
        public static HolidaySearchResult CheapestFlightAndHotelPackageQuery(HolidaySearchQuery holidaySearch, List<Flight> resultF, List<Hotel> resultH, int queryID)
        {
            HolidaySearchResult holidaySearchResults = new HolidaySearchResult();

            switch (queryID)
            {
                case 1:

                    try
                    {
                        // Find the cheapest suitable flight ...

                        var resultQueryID1 = from s in resultF
                                             where s.From == holidaySearch.From && s.To == holidaySearch.To && s.Departure_Date == holidaySearch.Departure_Date
                                             group s by s.Price into sg
                                             from record_group in sg
                                             orderby record_group.Price
                                             select new
                                             {
                                                 From = record_group.From,
                                                 To = record_group.To,
                                                 Departure_Date = record_group.Departure_Date,
                                                 Flight_Price = (int)record_group.Price!,
                                                 Flight_Id = record_group.Id,
                                             };

                        // Assign elements from the first query (containing the cheapest suitable flight) to the return class ...

                        foreach (var element in resultQueryID1.Take(1))
                        {
                                holidaySearchResults.Flight_From = element.From;
                                holidaySearchResults.Flight_To = element.To;
                                holidaySearchResults.Flight_Departure_Date = element.Departure_Date;
                                holidaySearchResults.Flight_Price = element.Flight_Price;
                                holidaySearchResults.Flight_Id = element.Flight_Id;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} : Exception in executing query: CheapestFlightAndHotelPackageQuery: queryID = {1}", e, queryID);
                    }

                    break;

                case 2:

                    try
                    {
                        // Find the cheapest suitable flight ...

                        var resultQueryID2 = from s in resultF
                                             where (s.From == "LGW" || s.From == "LTN") && s.To == holidaySearch.To && s.Departure_Date == holidaySearch.Departure_Date
                                             group s by s.Price into sg
                                             from record_group in sg
                                             orderby record_group.Price
                                             select new
                                             {
                                                 From = record_group.From,
                                                 To = record_group.To,
                                                 Departure_Date = record_group.Departure_Date,
                                                 Flight_Price = (int)record_group.Price!,
                                                 Flight_Id = record_group.Id,
                                             };

                        // Assign elements from the first query (containing the cheapest suitable flight) to the return class ...

                        foreach (var element in resultQueryID2.Take(1))
                        {
                            holidaySearchResults.Flight_From = element.From;
                            holidaySearchResults.Flight_To = element.To;
                            holidaySearchResults.Flight_Departure_Date = element.Departure_Date;
                            holidaySearchResults.Flight_Price = element.Flight_Price;
                            holidaySearchResults.Flight_Id = element.Flight_Id;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} : Exception in executing query: CheapestFlightAndHotelPackageQuery: queryID = {1}", e, queryID);
                    }

                    break;

                case 3:

                    try
                    {
                        // Find the cheapest suitable flight ...

                        var resultQueryID3 = from s in resultF
                                             where s.To == holidaySearch.To && s.Departure_Date == holidaySearch.Departure_Date
                                             group s by s.Price into sg
                                             from record_group in sg
                                             orderby record_group.Price
                                             select new
                                             {
                                                 From = record_group.From,
                                                 To = record_group.To,
                                                 Departure_Date = record_group.Departure_Date,
                                                 Flight_Price = (int)record_group.Price!,
                                                 Flight_Id = record_group.Id,
                                             };

                        // Assign elements from the first query (containing the cheapest suitable flight) to the return class ...

                        foreach (var element in resultQueryID3.Take(1))
                        {
                            holidaySearchResults.Flight_From = element.From;
                            holidaySearchResults.Flight_To = element.To;
                            holidaySearchResults.Flight_Departure_Date = element.Departure_Date;
                            holidaySearchResults.Flight_Price = element.Flight_Price;
                            holidaySearchResults.Flight_Id = element.Flight_Id;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} : Exception in executing query: CheapestFlightAndHotelPackageQuery: queryID = {1}", e, queryID);
                    }

                    break;

                default:

                    Console.WriteLine("{0} : Exception in executing query: CheapestFlightAndHotelPackageQuery: Faulty queryID = {1}", queryID);

                    return null!;
            }

            // Now find the cheapest suitable hotel ...

            var result3 = from s in resultH
                          where s.Arrival_Date == holidaySearch.Departure_Date && s.Local_Airports == holidaySearch.To && s.Nights == holidaySearch.Duration
                          group s by s.Price_Per_night into sg
                          from record_group in sg
                          orderby record_group.Price_Per_night
                          select new
                          {
                              Hotel_Name = record_group.Name,
                              Hotel_ID = record_group.Id,
                              Hotel_Price = record_group.Price_Per_night,
                              Flight_Id = record_group.Id,
                              Nights = record_group.Nights,

                          };

            // Assign elements of the second query (containing the cheapest suitable hotel) to the return class ...

            foreach (var element in result3.Take(1))
            {
                holidaySearchResults.Hotel_Id = element.Hotel_ID;
                holidaySearchResults.Hotel_Price = element.Hotel_Price;
                holidaySearchResults.Hotel_Name = element.Hotel_Name;
                holidaySearchResults.Hotel_Nights = element.Nights;

                holidaySearchResults.Total_Price = element.Hotel_Price + holidaySearchResults.Flight_Price;
            }

            return holidaySearchResults;
        }
    }
}
