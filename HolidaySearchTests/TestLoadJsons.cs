using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System;
using FluentAssertions;
using System.Globalization;
using System.Linq;
using OTBHolidaySearch1.HolidaySearchClasses;

namespace OTBHolidaySearch1.HolidaySearchTests
{
    public class TestsLoadJsons
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInitialiseLoadJson()
        {
            Assert.Pass();
        }

        [Test]
        public void TestReturnStringFromLoadDataFromJsonsFile()
        {
            const string TestString = "dummy_string_return_from_LoadDataFromJsonsFile";

            var ReturnString = LoadJson.LoadDataFromJsonsFile("dummy");

            ReturnString.Should().NotBeNull();
            ReturnString.Should().BeOfType<string>();
            ReturnString.Should().Be(TestString);

            Console.WriteLine($"{TestString} ");
        }
    }
}