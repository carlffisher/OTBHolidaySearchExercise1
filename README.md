# OTBHolidaySearch1


This is a program that searches data in two Lists constructed from Json files which contain Flight and Hotel data, repectively.
These files are searched to identify the cheapest available package holiday, (flight and hotel), according to customer requirements 
such as departure location and holiday destination.

The class ExecuteQuery.cs hosts the method CheapestFlightAndHotelPackageQuery, which receives as parameters:
customer generated HolidaySearchQuery data, a List of available flights., a List of available Hotels, and a query identifier.

According to the query identifier, a query is executed. Results are assigned to class instance HolidaySearchResult. This is returned
back to caller.

Unit testing is performed on all aspects of the program:

TestLoadJsons.cs

	to verify that the two Json files are correctly opened and read.
	to verify that the Json data parsed by the deserializer returns correct data

TestExecuteQuery.cs

	to verify that each of three test queries are correctly processed by CheapestFlightAndHotelPackageQuery in ExecuteQuery.cs 

Test results are also output to the Test Explorer window to aid the observer. 

