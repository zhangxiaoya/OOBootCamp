using System.Collections.Generic;
using Xunit;

namespace OOBootCamp
{
    public class FirstTest
    {
        [Fact]
        public void when_given_two_parking_area_should_return_the_parking_one()
        {
            var parkingAreaOne = new ParkingArea("Parking Area One", 100);
            var parkingAreaTwo = new ParkingArea("Parking Area Two", 1000);

            Assert.Equal("Parking Area One", ToolKit.WhichIsNear(parkingAreaOne,parkingAreaTwo));
        }

        [Fact]
        public void when_given_two_parking_area_should_return_the_parking_two()
        {
            var parkingAreaOne = new ParkingArea("Parking Area One", 100);
            var parkingAreaTwo = new ParkingArea("Parking Area Two", 10);

            Assert.Equal("Parking Area Two", ToolKit.WhichIsNear(parkingAreaOne, parkingAreaTwo));
        }

        [Fact]
        public void when_given_two_parking_area_with_unit_should_return_the_parking_one()
        {
            var parkingAreaOne = new ParkingArea("Parking Area One", 100, "m");
            var parkingAreaTwo = new ParkingArea("Parking Area Two", 10, "Km");

            Assert.Equal("Parking Area One", ToolKit.WhichIsNear(parkingAreaOne, parkingAreaTwo));
        }

        [Fact]
        public void when_given_two_parking_area_with_unit_should_return_the_parking_two()
        {
            var parkingAreaOne = new ParkingArea("Parking Area One", 100, "Km");
            var parkingAreaTwo = new ParkingArea("Parking Area Two", 10, "Km");

            Assert.Equal("Parking Area Two", ToolKit.WhichIsNear(parkingAreaOne, parkingAreaTwo));
        }

    }

    public class ToolKit {
        public static string WhichIsNear(ParkingArea parkingAreaOne, ParkingArea parkingAreaTwo)
        {
            if (parkingAreaOne._unit == parkingAreaTwo._unit)
            {
                return parkingAreaOne._distance < parkingAreaTwo._distance ? parkingAreaOne._parkingAreaName : parkingAreaTwo._parkingAreaName;
            }
            if (parkingAreaOne._unit == "Km")
            {
                parkingAreaOne._distance *= 1000;
            }
            else
            {
                parkingAreaTwo._distance *= 1000;
            }
            return parkingAreaOne._distance < parkingAreaTwo._distance ? parkingAreaOne._parkingAreaName : parkingAreaTwo._parkingAreaName;
        }
    }

    public class ParkingArea
    {
        public string _unit { get; set; }
        public string _parkingAreaName { get; set; }
        public int _distance { get; set; }

        public ParkingArea(string parkingAreaName, int distance, string unit = "m")
        {
            _parkingAreaName = parkingAreaName;
            _distance = distance;
            _unit = unit;
        }
    }
}