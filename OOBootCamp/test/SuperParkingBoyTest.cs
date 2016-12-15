using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class SuperParkingBoyTest
    {
        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_vacancy_rate_first_test()
        {
            var parkingLotWithHighRate = new ParkingLot(4);
            parkingLotWithHighRate.Park(new Car());
            var parkingLotWithLowRate = new ParkingLot(3);
            parkingLotWithLowRate.Park(new Car());
            var superParkingBoy = new SuperParkingBoy(new []
            {
                parkingLotWithHighRate,
                parkingLotWithLowRate
            });
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car,parkingLotWithHighRate.Pick(carToken));
        }

        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_vacancy_rate_second_test()
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
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, parkingLotWithHighRate.Pick(carToken));
        }

        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_vacancy_rate_and_less_parking_space()
        {
            var parkingLotWithHighRate = new ParkingLot(3);
            parkingLotWithHighRate.Park(new Car());
            var parkingLotWithLowRate = new ParkingLot(6);
            parkingLotWithLowRate.Park(new Car());
            parkingLotWithLowRate.Park(new Car());
            parkingLotWithLowRate.Park(new Car());
            var superParkingBoy = new SuperParkingBoy(new[]
            {
                parkingLotWithHighRate,
                parkingLotWithLowRate
            });
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, parkingLotWithHighRate.Pick(carToken));
        }


        [Fact]
        public void should_park_one_car_to_one_of_parking_lots_while_all_have_same_vacancy_rate()
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

        [Fact]
        public void should_pick_correct_car()
        {
            var parkingLotWithHighVacancyRate = new ParkingLot(5);
            var parkingLotWithLowVacancyRate = new ParkingLot(3);
            var superParkingBoy = new SuperParkingBoy(new[]
            {
                parkingLotWithHighVacancyRate,
                parkingLotWithLowVacancyRate
            });
            parkingLotWithLowVacancyRate.Park(new Car());
            parkingLotWithHighVacancyRate.Park(new Car());
            var car = new Car();

            var carToken = parkingLotWithHighVacancyRate.Park(car);

            Assert.Same(car, superParkingBoy.Pick(carToken));
        }

        [Fact]
        public void should_not_pick_correct_car_while_no_parking()
        {
            var parkingLotWithHighVacancyRate = new ParkingLot(4);
            var parkingLotWithLowVacancyRate = new ParkingLot(3);
            var superParkingBoy = new SuperParkingBoy(new[]
            {
                parkingLotWithHighVacancyRate,
                parkingLotWithLowVacancyRate
            });

            const int illegalCarToken = 0;

            Assert.Same(null, superParkingBoy.Pick(illegalCarToken));
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