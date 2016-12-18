using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_park_one_car()
        {
            var parkingLot = new ParkingLot(4);
            var parkingBoy = new ParkingBoy(new[]{parkingLot});
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car,parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_one_car_to_first_avaliable_parking_lot()
        {
            var parkingLotOne = new ParkingLot(4);
            var parkingLotTwo = new ParkingLot(4);
            var parkingBoy = new ParkingBoy(new[]{parkingLotOne,parkingLotTwo});
            TakeAllParkingSpaceOfParkingLot(parkingLotOne);
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, parkingLotTwo.Pick(token));
        }

        [Fact]
        public void should_not_park_one_car_while_no_one_parking_lot_available()
        {
            var parkingLotOne = new ParkingLot(4);
            var parkingLotTwo = new ParkingLot(4);
            var parkingBoy = new ParkingBoy(new[] { parkingLotOne, parkingLotTwo });
            TakeAllParkingSpaceOfParkingLot(parkingLotOne);
            TakeAllParkingSpaceOfParkingLot(parkingLotTwo);
            var car = new Car();

            var illegaltoken = parkingBoy.Park(car);

            Assert.Same(null, parkingLotOne.Pick(illegaltoken));
            Assert.Same(null, parkingLotTwo.Pick(illegaltoken));
        }

        [Fact]
        public void should_pick_one_car()
        {
            var parkingLot = new ParkingLot(4);
            var parkingBoy = new ParkingBoy(new[] { parkingLot});
            var car = new Car();

            var token = parkingBoy.Park(car);

            var pickCar = parkingBoy.Pick(token);
            Assert.Same(car, pickCar);
        }

        [Fact]
        public void should_pick_one_car_when_have_two_parking_lots()
        {
            var parkingLotOne = new ParkingLot(4);
            var parkingLotTwo = new ParkingLot(4);
            var parkingBoy = new ParkingBoy(new[] { parkingLotOne,parkingLotTwo });
            TakeAllParkingSpaceOfParkingLot(parkingLotOne);
            var car = new Car();

            var token = parkingBoy.Park(car);

            var pickCar = parkingBoy.Pick(token);
            Assert.Same(car, pickCar);
        }

        [Fact]
        public void should_not_pick_one_car_while_no_car_parking()
        {
            var parkingLot = new ParkingLot(4);
            var parkingBoy = new ParkingBoy(new[] { parkingLot });
            const int illegalToken = 0;

            var pickCar = parkingBoy.Pick(illegalToken);

            Assert.Same(null, pickCar);
        }

        private static void TakeAllParkingSpaceOfParkingLot(ParkingLot parkingLot)
        {
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
        }
    }
}