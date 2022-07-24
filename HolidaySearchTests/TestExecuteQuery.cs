using FluentAssertions;
using Newtonsoft.Json;
using OTBHolidaySearch1.HolidaySearchClasses;
using OTBHolidaySearch1.Flights; using OTBHolidaySearch1.Hotels;
using OTBHolidaySearch1.HolidaySearch;

namespace OTBHolidaySearch1.HolidaySearchTests
{
    public class TestsExecuteQuery
    {
        private static readonly DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
           Directory.GetParent(
               Directory.GetParent(
                   Directory.GetCurrentDirectory())?
                   .ToString() ?? string.Empty)?.ToString()
           ?? string.Empty)?.ToString() ?? string.Empty);

        public string filePathFlights = DatasetPath + "/OTBHolidaySearch1/JsonData/JsonFlights.json";
        public string filePathHotels = DatasetPath + "/OTBHolidaySearch1/JsonData/JsonHotels.json";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestInitialise()
        {
            Assert.Pass();
        }

        [Test]
        public void TestReturnDataFromExecuteHolidaySearchQuery1()
        {
            // Arrange ...

            int queryID = 1;

            // Because there is a seperate test for each query, json files are read and deserialized for each ...

            // Arrange ...
            
            var jsonF1 = File.ReadAllText(filePathFlights);
            var jsonH1 = File.ReadAllText(filePathHotels);

            // Because deserializer has trouble parsing [ and ] in Json values ...

            var newjsonF1 = jsonF1.Replace(" [", " ");
            var newjsonF2 = newjsonF1.Replace("],", ",");

            var newjsonH1 = jsonH1.Replace(" [", " ");
            var newjsonH2 = newjsonH1.Replace("],", ",");

            var resultF = JsonConvert.DeserializeObject<List<Flight>>(newjsonF1);
            var resultH = JsonConvert.DeserializeObject<List<Hotel>>(newjsonH2);

            //  The test query ... 

            HolidaySearchQuery holidaySearchQuery = new HolidaySearchQuery
            {
                From = "MAN",
                To = "AGP",
                Departure_Date = "2023-07-01",
                Duration = 7
            };

            // Act ...

            var result = ExecuteHolidayQuery.CheapestFlightAndHotelPackageQuery(holidaySearchQuery, resultF!, resultH!, queryID );

            // Assert ...

            result.Total_Price.Should().Be(328);
            result.Flight_Id.Should().Be(2);
            result.Flight_Departure_Date.Should().Be("2023-07-01");
            result.Flight_From.Should().Be("MAN");
            result.Flight_To.Should().Be("AGP");
            result.Flight_Price.Should().Be(245);
            result.Hotel_Id.Should().Be(9);
            result.Hotel_Name.Should().Be("Nh Malaga");
            result.Hotel_Nights.Should().Be(7);
            result.Hotel_Price.Should().Be(83);

            Console.WriteLine(" TOTAL PACKAGE PRICE   = £{0}", result.Total_Price);
            Console.WriteLine("  ");

            Console.WriteLine(" Flight Id             = {0} ", result.Flight_Id);
            Console.WriteLine(" Flight Departure_Date = {0} ", result.Flight_Departure_Date);
            Console.WriteLine(" Flight From           = {0} ", result.Flight_From);
            Console.WriteLine(" Flight To             = {0} ", result.Flight_To);
            Console.WriteLine(" FlightPrice           = £{0}", result.Flight_Price);
            Console.WriteLine("  ");

            Console.WriteLine(" Hotel_Id              = {0} ", result.Hotel_Id);
            Console.WriteLine(" Hotel_Name            = {0} ", result.Hotel_Name);
            Console.WriteLine(" Number of nights      = {0} ", result.Hotel_Nights);
            Console.WriteLine(" Hotel_Price           = £{0}", result.Hotel_Price);
        }

        [Test]
        public void TestReturnDataFromExecuteHolidaySearchQuery2()
        {
            // Arrange ...

            int queryID = 2;

            // Because there is a seperate test for each query, json files are read and deserialized each time ...

            var jsonF1 = File.ReadAllText(filePathFlights);
            var jsonH1 = File.ReadAllText(filePathHotels);

            // Because deserializer has trouble parsing [ and ] in Json values ...

            var newjsonF1 = jsonF1.Replace(" [", " ");
            var newjsonF2 = newjsonF1.Replace("],", ",");

            var newjsonH1 = jsonH1.Replace(" [", " ");
            var newjsonH2 = newjsonH1.Replace("],", ",");

            var resultF = JsonConvert.DeserializeObject<List<Flight>>(newjsonF1);
            var resultH = JsonConvert.DeserializeObject<List<Hotel>>(newjsonH2);

            //  The test query ... 

            HolidaySearchQuery holidaySearchQuery = new HolidaySearchQuery
            {
                From = "Any London Airport",
                To = "PMI",
                Departure_Date = "2023-06-15",
                Duration = 10
            };

            // Act ...

            var result = ExecuteHolidayQuery.CheapestFlightAndHotelPackageQuery(holidaySearchQuery, resultF!, resultH!, queryID);

            // Assert ...

            result.Total_Price.Should().Be(135);
            result.Flight_Id.Should().Be(6);
            result.Flight_Departure_Date.Should().Be("2023-06-15");
            result.Flight_From.Should().Be("LGW");
            result.Flight_To.Should().Be("PMI");
            result.Flight_Price.Should().Be(75);
            result.Hotel_Id.Should().Be(5);
            result.Hotel_Name.Should().Be("Sol Katmandu Park & Resort");
            result.Hotel_Nights.Should().Be(10);
            result.Hotel_Price.Should().Be(60); 

            Console.WriteLine(" TOTAL PACKAGE PRICE   = £{0}", result.Total_Price);
            Console.WriteLine("  ");

            Console.WriteLine(" Flight Id             = {0} ", result.Flight_Id);
            Console.WriteLine(" Flight Departure_Date = {0} ", result.Flight_Departure_Date);
            Console.WriteLine(" Flight From           = {0} ", result.Flight_From);
            Console.WriteLine(" Flight To             = {0} ", result.Flight_To);
            Console.WriteLine(" FlightPrice           = £{0}", result.Flight_Price);
            Console.WriteLine("  ");

            Console.WriteLine(" Hotel_Id              = {0} ", result.Hotel_Id);
            Console.WriteLine(" Hotel_Name            = {0} ", result.Hotel_Name);
            Console.WriteLine(" Number of nights      = {0} ", result.Hotel_Nights);
            Console.WriteLine(" Hotel_Price           = £{0}", result.Hotel_Price);
        }

        [Test]
        public void TestReturnDataFromExecuteHolidaySearchQuery3()
        {
            // Arrange ...

            int queryID = 3;

            // Because there is a seperate test for each query, json files are read and deserialized each time ...

            var jsonF1 = File.ReadAllText(filePathFlights);
            var jsonH1 = File.ReadAllText(filePathHotels);

            // Because deserializer has trouble parsing [ and ] in Json values ...

            var newjsonF1 = jsonF1.Replace(" [", " ");
            var newjsonF2 = newjsonF1.Replace("],", ",");

            var newjsonH1 = jsonH1.Replace(" [", " ");
            var newjsonH2 = newjsonH1.Replace("],", ",");

            var resultF = JsonConvert.DeserializeObject<List<Flight>>(newjsonF1);
            var resultH = JsonConvert.DeserializeObject<List<Hotel>>(newjsonH2);

            //  The test query ... 

            HolidaySearchQuery holidaySearchQuery = new HolidaySearchQuery
            {
                From = "Any",
                To = "LPA",
                Departure_Date = "2022-11-10",
                Duration = 14
            };

            // Act ...

            var result = ExecuteHolidayQuery.CheapestFlightAndHotelPackageQuery(holidaySearchQuery, resultF!, resultH!, queryID);

            // Assert ...

            result.Total_Price.Should().Be(200);
            result.Flight_Id.Should().Be(7);
            result.Flight_Departure_Date.Should().Be("2022-11-10");
            result.Flight_From.Should().Be("MAN");
            result.Flight_To.Should().Be("LPA");
            result.Flight_Price.Should().Be(125);
            result.Hotel_Id.Should().Be(6);
            result.Hotel_Name.Should().Be("Club Maspalomas Suites and Spa");
            result.Hotel_Nights.Should().Be(14);
            result.Hotel_Price.Should().Be(75); 
            
            Console.WriteLine(" TOTAL PACKAGE PRICE   = £{0}", result.Total_Price);
            Console.WriteLine("  ");

            Console.WriteLine(" Flight Id             = {0} ", result.Flight_Id);
            Console.WriteLine(" Flight Departure_Date = {0} ", result.Flight_Departure_Date);
            Console.WriteLine(" Flight From           = {0} ", result.Flight_From);
            Console.WriteLine(" Flight To             = {0} ", result.Flight_To);
            Console.WriteLine(" FlightPrice           = £{0}", result.Flight_Price);
            Console.WriteLine("  ");

            Console.WriteLine(" Hotel_Id              = {0} ", result.Hotel_Id);
            Console.WriteLine(" Hotel_Name            = {0} ", result.Hotel_Name);
            Console.WriteLine(" Number of nights      = {0} ", result.Hotel_Nights);
            Console.WriteLine(" Hotel_Price           = £{0}", result.Hotel_Price);
        }
    }
}