using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void should_park_car_while_only_one_parking_lots()
        {
            var parkingLot = new ParkingLot(2);
            var samrtParkingBoy = new SamrtParkingBoy(new[] { parkingLot });
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_car_in_one_of_them_while_all_parking_lot_have_same_count_of_space()
        {
            var parkingLotOne = new ParkingLot(2);
            var parkingLotTwo = new ParkingLot(2);
            var samrtParkingBoy = new SamrtParkingBoy(new[] {parkingLotOne, parkingLotTwo});
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            var actuaPickedCarFromParkingLotOne = parkingLotOne.Pick(token);
            var actuaPickedCarFromParkingLotTwo = parkingLotOne.Pick(token);
            Assert.Same(car, AssertOneOfIsTrue(new[]{actuaPickedCarFromParkingLotOne, actuaPickedCarFromParkingLotTwo}));
        }

        [Fact]
        public void should_pick_car_while_only_one_paring_lot()
        {
            var parkingLot = new ParkingLot(2);
            var samrtParkingBoy = new SamrtParkingBoy(new[] { parkingLot});
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, samrtParkingBoy.Pick(token));
        }

        [Fact]
        public void should_pick_car_while_have_two_paring_lots()
        {
            var parkingLotOne = new ParkingLot(2);
            var parkingLotTwo = new ParkingLot(3);
            var samrtParkingBoy = new SamrtParkingBoy(new[] { parkingLotOne, parkingLotTwo });
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, samrtParkingBoy.Pick(token));
        }

        private static Car AssertOneOfIsTrue(IEnumerable<Car> cars)
        {
            var count = 0;
            Car acturalCar = null;
            foreach (var car in cars.Where(car => car != null)) {
                count++;
                acturalCar = car;
            }
            return count != 1 ? acturalCar : null;
        }
    }
}