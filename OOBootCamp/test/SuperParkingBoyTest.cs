using System.Collections.Generic;
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
            var parkingLotWithHighRate = CreateParkingLotAndParkSomeCar(4, 1);
            var parkingLotWithLowRate = CreateParkingLotAndParkSomeCar(3, 1);
            var superParkingBoy = new SuperParkingBoy(new List<ParkingLot>
            {
                parkingLotWithHighRate,
                parkingLotWithLowRate
            });
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, parkingLotWithHighRate.Pick(carToken));
        }

        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_vacancy_rate_second_test()
        {
            var parkingLotWithLowRate = CreateParkingLotAndParkSomeCar(2, 1);
            var parkingLotWithHighRate = CreateParkingLotAndParkSomeCar(3, 1);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLotWithLowRate, parkingLotWithHighRate});
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, parkingLotWithHighRate.Pick(carToken));
        }

        [Fact]
        public void should_park_one_car_to_parking_lot_which_have_high_vacancy_rate_and_less_parking_space()
        {
            var parkingLotWithHighRate = CreateParkingLotAndParkSomeCar(3, 1);
            var parkingLotWithLowRate = CreateParkingLotAndParkSomeCar(6, 3);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLotWithHighRate, parkingLotWithLowRate});
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, parkingLotWithHighRate.Pick(carToken));
        }

        [Fact]
        public void should_park_one_car_to_one_of_parking_lots_while_all_have_same_vacancy_rate()
        {
            var parkingLot = CreateParkingLotAndParkSomeCar(2, 1);
            var parkingLotWithSameRate = CreateParkingLotAndParkSomeCar(2, 1);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLot, parkingLotWithSameRate});
            var car = new Car();

            var carToken = superParkingBoy.Park(car);

            Assert.Same(car, CarParkingInOneOfParkingLots(new[] {parkingLot.Pick(carToken), parkingLotWithSameRate.Pick(carToken)}));
        }

        [Fact]
        public void should_pick_correct_car()
        {
            var parkingLotWithHighVacancyRate = CreateParkingLotAndParkSomeCar(5, 1);
            var parkingLotWithLowVacancyRate = CreateParkingLotAndParkSomeCar(3, 1);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLotWithHighVacancyRate, parkingLotWithLowVacancyRate});
            var car = new Car();

            var carToken = parkingLotWithHighVacancyRate.Park(car);

            Assert.Same(car, superParkingBoy.Pick(carToken));
        }

        [Fact]
        public void should_not_pick_correct_car_while_no_parking()
        {
            var parkingLotWithHighVacancyRate = CreateParkingLotAndParkSomeCar(4, 1);
            var parkingLotWithLowVacancyRate = CreateParkingLotAndParkSomeCar(3, 1);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLotWithHighVacancyRate, parkingLotWithLowVacancyRate});

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

        private static ParkingLot CreateParkingLotAndParkSomeCar(uint capacity, int carNumber)
        {
            var parkingLotWithHighRate = new ParkingLot(capacity);
            while (carNumber-- != 0)
            {
                parkingLotWithHighRate.Park(new Car());
            }
            return parkingLotWithHighRate;
        }
    }
}