using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void should_park_one_car_to_second_parking_lot_while_both_available_but_second_one_have_more_space()
        {
            var parkingLotOne = new ParkingLot(2);
            var parkingLotTwo = new ParkingLot(3);
            var samrtParkingBoy = new SamrtParkingBoy(new[] { parkingLotOne, parkingLotTwo });
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, parkingLotTwo.Pick(token));
        }
    }
}