using Xunit;

namespace OOBootCamp
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_park_the_pick_one_car()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);

            var car = new Car();
            var token = parkingBoy.Park(car);

            Assert.Same(car,parkingLot.Pick(token));
        }
    }
}