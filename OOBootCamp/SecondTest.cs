using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Xml;
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

            Assert.Equal(car.GetHashCode(), parkingAreaA.Park(car));
            Assert.Equal(car, parkingAreaA.UnPark(car.GetHashCode()));

        }

        [Fact]
        public void when_parking_two_cars_get_one_car_should_get_all_car()
        {
            var car1 = new Car();
            var car2 = new Car();

            var parkingAreaA = new ParkingAreaA();

            Assert.Equal(car1.GetHashCode(),parkingAreaA.Park(car1));
            Assert.Equal(car2.GetHashCode(),parkingAreaA.Park(car2));

            var unAllPark = parkingAreaA.UnAllPark();

            Assert.Equal(car1, unAllPark[0]);   
            Assert.Equal(car2, unAllPark[1]);   
        }

        [Fact]
        public void when_parking_one_car_should_not_unpark_this_car_twice()
        {
            var car = new Car();

            var parkingAreaA = new ParkingAreaA();

            parkingAreaA.Park(car);

            parkingAreaA.UnPark(car.GetHashCode());

            Assert.Null(parkingAreaA.UnPark(car.GetHashCode()));
        }

        [Fact]
        public void should_return_remain_parking_space()
        {
            var car = new Car();

            var parkingAreaA = new ParkingAreaA();
            parkingAreaA.Park(car);

            Assert.Equal((uint)3, parkingAreaA.remianParkingSpace()); 
        }

        [Fact]
        public void should_return_4_when_no_car_parking()
        {
            var parkingAreaA = new ParkingAreaA();

            Assert.Equal((uint)4, parkingAreaA.remianParkingSpace());
        }

        [Fact]
        public void should_return_0_when_4_cars_parking()
        {
            var parkingAreaA = new ParkingAreaA();

            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());

            Assert.Equal((uint)0, parkingAreaA.remianParkingSpace());
        }

        [Fact]
        public void should_return_0_and_last_car_can_not_parking_when_5_cars_parking()
        {
            var parkingAreaA = new ParkingAreaA();

            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            var lastCarParkingStatus = parkingAreaA.Park(new Car());

            Assert.Equal(lastCarParkingStatus,0);

            Assert.Equal((uint)0, parkingAreaA.remianParkingSpace());
        }

        [Fact]
        public void should_return_3_when_parking_2_cars_and_unparking_1_car()
        {
            var parkingAreaA = new ParkingAreaA();

            var car = new Car();
            parkingAreaA.Park(car);
            parkingAreaA.Park(new Car());

            parkingAreaA.UnPark(car.GetHashCode());

            Assert.Equal((uint)3, parkingAreaA.remianParkingSpace());
        }
    }

    public class ParkingAreaA {
        private IList<Car> _allCar;
        private uint _remainPosition;

        public ParkingAreaA()
        {
            _remainPosition = 4;
            _allCar = new List<Car>();
        }

        public int Park(Car car)
        {
            if (_remainPosition > 0)
            {
                _allCar.Add(car);
                _remainPosition = _remainPosition - 1;
                return car.GetHashCode();
            }
            else
            {
                return 0;
            }
        }

        public Car UnPark(int token)
        {
            foreach (var car in _allCar)
            {
                if (car.GetHashCode().Equals(token))
                {
                    _allCar.Remove(car);
                    _remainPosition++;
                    return car;
                }
            }
            return null;
        }

        public IList<Car> UnAllPark()
        {
            return _allCar;
        }

        public uint remianParkingSpace()
        {
            return _remainPosition;
        }
    }

    public class Car {}
}