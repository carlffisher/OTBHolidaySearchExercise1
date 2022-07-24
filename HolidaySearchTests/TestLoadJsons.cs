
using FluentAssertions;
using Newtonsoft.Json;
using OTBHolidaySearch1.Flights;
using OTBHolidaySearch1.Hotels;

namespace OTBHolidaySearch1.HolidaySearchTests
{
    public class TestsLoadJsons
    {
        private static readonly DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
           Directory.GetParent(
               Directory.GetParent(
                   Directory.GetCurrentDirectory())?
                   .ToString() ?? string.Empty)?.ToString()
           ?? string.Empty)?.ToString() ?? string.Empty);

        public string filePathFlights = DatasetPath + "/OTBHolidaySearch1/JsonData/SubJsonFlights.json";
        public string filePathHotels  = DatasetPath + "/OTBHolidaySearch1/JsonData/SubJsonHotels.json";

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
        public void TestReturnFlightDataFromJsonFile()
        {
            // Read a single json record from json flights datafile ...

            // Act ...

            var json = File.ReadAllText(filePathFlights);

            // Assert ...
            
            json.Should().NotBeNull();
            json.Should().BeOfType<string>();
            json.Length.Should().Be(158);
        }

        [Test]
        public void TestReturnHotelDataFromJsonFile()
        {
            // Read a single json record from json hotels datafile ...

            // Act ...
            
            var json = File.ReadAllText(filePathHotels);

            // Assert ...

            json.Should().NotBeNull();
            json.Should().BeOfType<string>();
            json.Length.Should().Be(186);
        }

        [Test]
        public void TestReturnFlightDataFromDeserializer()
        {
            // Read a single json record from flights datafile and deserialize. Test for expected contents ...

            // Act ...
            
            var json = File.ReadAllText(filePathFlights);

            // Assert ...
            
            json.Should().NotBeNull();
            json.Should().BeOfType<string>();

            // because deserializer has trouble parsing [ and ] in Json values ...

            // Arrange ...
            
            var newjson = json.Replace(" [", " ");
            var newjson2 = newjson.Replace("],", ",");
            Console.WriteLine("newjson {0}", newjson2);

            // Act ...
            
            var result = JsonConvert.DeserializeObject<List<Flight>>(newjson2);

            // Assert ...
            
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Flight>>();
            result!.Count.Should().Be(1);

            foreach (var item in result)
            {
                Console.WriteLine("FLIGHTS: Id : {0} Airline : {1} From : {2} To : {3} Price : {4} Departure_Date : {5}",
                                    item.Id,
                                    item.Airline,
                                    item.From,
                                    item.To,
                                    item.Price,
                                    item.Departure_Date);

                item.Id.Should().Be(1);
                item.Airline.Should().Be("First Class Air");
                item.From.Should().Be("MAN");
                item.To.Should().Be("TFS");
                item.Price.Should().Be(470);
                item.Departure_Date.Should().Be("2023-07-01");
            }
        }

        [Test]
        public void TestReturnHotelDataFromDeserializer()
        {
            // Read a single json record from hotels datafile and deserialize. Test for expected contents ...

            // Act ...
            
            var json = File.ReadAllText(filePathHotels);

            // Assert ..

            json.Should().NotBeNull();
            json.Should().BeOfType<string>();

            // because deserializer has trouble parsing [ and ] in Json values ...

            // Arrange

            var newjson = json.Replace(" [", " ");
            var newjson2 = newjson.Replace("],",",");
            Console.WriteLine("newjson {0}", newjson2);

            // Act ...

            var result = JsonConvert.DeserializeObject<List<Hotel>>(newjson2);

            // Assert ...

            result.Should().NotBeNull();
            result.Should().BeOfType<List<Hotel>>();
            result!.Count.Should().Be(1);
            
            foreach (var item in result)
            {
               Console.WriteLine("HOTELS: Id : {0} Name : {1} Arrival_Date : {2} Price_Per_night : {3} Local_Airports : {4} Nights : {5}",
                                       item.Id,
                                       item.Name,
                                       item.Arrival_Date,
                                       item.Price_Per_night,
                                       item.Local_Airports,
                                       item.Nights);

                item.Id.Should().Be(1);
                item.Name.Should().Be("Iberostar Grand Portals Nous");
                item.Arrival_Date.Should().Be("2022-11-05");
                item.Price_Per_night.Should().Be(100);
                item.Local_Airports.Should().Be("TFS");
                item.Nights.Should().Be(7);
            }
        }
    }
}