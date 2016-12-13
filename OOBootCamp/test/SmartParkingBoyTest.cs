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
            var samrtParkingBoy = new SamrtParkingBoy(new[] {parkingLot});
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_car_in_one_of_them_while_two_parking_lot_have_different_parking_number()
        {
            var parkingLotWithLessUnusedParkingSpace = new ParkingLot(2);
            var parkingLotWithMoreUnusedParkingSpace = new ParkingLot(3);
            var samrtParkingBoy = new SamrtParkingBoy(new[] { parkingLotWithLessUnusedParkingSpace, parkingLotWithMoreUnusedParkingSpace });
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, parkingLotWithMoreUnusedParkingSpace.Pick(token));
        }

        [Fact]
        public void should_park_car_in_the_one_more_parking_space_while_two_parking_lots_have_same_count_of_space()
        {
            var parkingLotWithLessParkingSpace = new ParkingLot(2);
            var parkingLotWithMoreParkingSpace = new ParkingLot(2);
            var samrtParkingBoy = new SamrtParkingBoy(new[] {parkingLotWithLessParkingSpace, parkingLotWithMoreParkingSpace});
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            var actuaPickedCarFromParkingLotOne = parkingLotWithLessParkingSpace.Pick(token);
            var actuaPickedCarFromParkingLotTwo = parkingLotWithMoreParkingSpace.Pick(token);
            Assert.Same(car, AssertOneOfIsTrue(new[] {actuaPickedCarFromParkingLotOne, actuaPickedCarFromParkingLotTwo}));
        }

        [Fact]
        public void test_case()
        {
            var P1 = new ParkingLot(1);
            var P2 = new ParkingLot(3);
            var P3 = new ParkingLot(2);
            var samrtParkingBoy = new SamrtParkingBoy(new[] { P1, P2, P3 });
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            var actuaPickedCarFromParkingLotTwo = P2.Pick(token);
            Assert.Same(car, actuaPickedCarFromParkingLotTwo);
        }


        [Fact]
        public void should_pick_car_while_only_one_paring_lot()
        {
            var parkingLot = new ParkingLot(2);
            var samrtParkingBoy = new SamrtParkingBoy(new[] {parkingLot});
            var car = new Car();

            var token = samrtParkingBoy.Park(car);

            Assert.Same(car, samrtParkingBoy.Pick(token));
        }

        [Fact]
        public void should_pick_car_while_have_two_paring_lots()
        {
            var parkingLotOne = new ParkingLot(2);
            var parkingLotTwo = new ParkingLot(3);
            var samrtParkingBoy = new SamrtParkingBoy(new[] {parkingLotOne, parkingLotTwo});
            var car = new Car();
            var token = parkingLotTwo.Park(car);

            var actualPickedCar = samrtParkingBoy.Pick(token);

            Assert.Same(car, actualPickedCar);
        }

        private static Car AssertOneOfIsTrue(IEnumerable<Car> cars)
        {
            var count = 0;
            Car acturalCar = null;
            foreach (var car in cars.Where(car => car != null)) {
                count++;
                acturalCar = car;
            }
            return count != 1 ? null : acturalCar;
        }
    }
}