using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class SuperParkingBoyTest
    {
        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_cacancy_rate_first_test()
        {
            var parkingLotWithHighRate = new ParkingLot(4);
            var parkingLotWithLowRate = new ParkingLot(3);
            var superParkingBoy = new SuperParkingBoy(new []
            {
                parkingLotWithHighRate,
                parkingLotWithLowRate
            });
            parkingLotWithHighRate.Park(new Car());
            parkingLotWithLowRate.Park(new Car());
            var carParingFirstTime = new Car();

            var firstTimeParkingCarToken = superParkingBoy.Park(carParingFirstTime);

            Assert.Same(carParingFirstTime,parkingLotWithHighRate.Pick(firstTimeParkingCarToken));
        }

        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_cacancy_rate_second_test()
        {
            var parkingLotWithLowRate = new ParkingLot(2);
            var parkingLotWithHighRate = new ParkingLot(3);
            var superParkingBoy = new SuperParkingBoy(new[]
            {
                parkingLotWithLowRate,
                parkingLotWithHighRate
            });
            parkingLotWithHighRate.Park(new Car());
            parkingLotWithLowRate.Park(new Car());
            var carParingSecondTime = new Car();

            var firstTimeParkingCarToken = superParkingBoy.Park(carParingSecondTime);

            Assert.Same(carParingSecondTime, parkingLotWithHighRate.Pick(firstTimeParkingCarToken));
        }

        [Fact]
        public void should_park_one_car_to_one_of_parking_lots_while_all_have_same_cacancy_rate()
        {
            var parkingLot = new ParkingLot(2);
            var parkingLotWithSameRate = new ParkingLot(2);
            var superParkingBoy = new SuperParkingBoy(new[]
            {
                parkingLot,
                parkingLotWithSameRate
            });
            parkingLotWithSameRate.Park(new Car());
            parkingLot.Park(new Car());
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, CarParkingInOneOfParkingLots(new []{parkingLot.Pick(carToken),parkingLotWithSameRate.Pick(carToken)}));
        }

        private static Car CarParkingInOneOfParkingLots(Car[] cars)
        {
            var count = 0;
            Car pickedCar = null;
            foreach (var car in cars)
            {
                if (car != null)
                {
                    count ++;
                    pickedCar = car;
                }
            }
            return count == 1 ? pickedCar : null;
        }
    }
}