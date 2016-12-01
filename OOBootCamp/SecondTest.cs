using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace OOBootCamp
{
    public class SecondTest
    {
        [Fact]
        public void when_Jhon_parking_one_car_should_get_his_car()
        {
            var car = new Car();
            var parkingAreaA = new ParkingAreaA();

            parkingAreaA.Park(car);

            Assert.Equal(car, parkingAreaA.UnPark());

        }

        [Fact]
        public void when_parking_two_cars_get_one_car_should_get_all_car()
        {
            var car1 = new Car();
            var car2 = new Car();

            var parkingAreaA = new ParkingAreaA();

            parkingAreaA.Park(car1);
            parkingAreaA.Park(car2);

            var unAllPark = parkingAreaA.UnAllPark();
            Assert.Equal(car1, unAllPark[0]);   
            Assert.Equal(car2, unAllPark[1]);   
        }
    }

    public class ParkingAreaA {
        private IList<Car> _allCar;

        public ParkingAreaA()
        {
            _allCar = new List<Car>();
        }

        public void Park(Car car)
        {
            _allCar.Add(car);
        }

        public Car UnPark()
        {
            return _allCar[0];
        }

        public IList<Car> UnAllPark()
        {
            return _allCar;
        }
    }

    public class Car {
    }
}