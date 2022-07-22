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
    public class TestsExecuteQuery
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInitialiseExecuteQuery()
        {
            Assert.Pass();
        }

        [Test]
        public void TestReturnStringFromExecuteHolidaySearchQuery()
        {
            const string TestString = "dummy_string_return_from_ExecuteHolidaySearchQuery";

            var ReturnString = ExecuteQuery.ExecuteHolidaySearchQuery("dummy");

            ReturnString.Should().NotBeNull();
            ReturnString.Should().BeOfType<string>();
            ReturnString.Should().Be(TestString);

            Console.WriteLine($"{TestString} ");
        }
    }
}