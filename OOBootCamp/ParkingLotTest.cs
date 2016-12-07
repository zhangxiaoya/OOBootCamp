using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using Xunit;

namespace OOBootCamp
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_park_and_pick_one_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();

            var token = parkingLot.Park(car);

            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_pick_the_right_one_when_park_two_car()
        {
            var car1 = new Car();
            var car2 = new Car();
            var parkingLot = new ParkingLot();

            var token = parkingLot.Park(car1);
            parkingLot.Park(car2);

            Assert.Same(car1, parkingLot.Pick(token));
        }

        [Fact]
        public void should_not_pick_one_car_twice()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();

            var token = parkingLot.Park(car);

            Assert.Same(car,parkingLot.Pick(token));
            Assert.Null(parkingLot.Pick(car.GetHashCode()));
        }

        [Fact]
        public void should_not_park_when_parklot_is_full()
        {
            var parkingLot = new ParkingLot();
            var invalidToekn = 0;

            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            var parkToken = parkingLot.Park(new Car());

            Assert.Equal(invalidToekn,parkToken);
        }

        [Fact]
        public void should_return_remain_parking_space()
        {
            var car = new Car();

            var parkingAreaA = new ParkingLot();
            parkingAreaA.Park(car);

            Assert.Equal((uint)3, parkingAreaA.remianParkingSpace()); 
        }

        [Fact]
        public void should_return_4_when_no_car_parking()
        {
            var parkingAreaA = new ParkingLot();

            Assert.Equal((uint)4, parkingAreaA.remianParkingSpace());
        }

        [Fact]
        public void should_return_0_when_4_cars_parking()
        {
            var parkingAreaA = new ParkingLot();

            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());

            Assert.Equal((uint)0, parkingAreaA.remianParkingSpace());
        }

        [Fact]
        public void should_return_0_and_last_car_can_not_parking_when_5_cars_parking()
        {
            var parkingAreaA = new ParkingLot();

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
            var parkingAreaA = new ParkingLot();

            var car = new Car();
            parkingAreaA.Park(car);
            parkingAreaA.Park(new Car());

            parkingAreaA.Pick(car.GetHashCode());

            Assert.Equal((uint)3, parkingAreaA.remianParkingSpace());
        }

        [Fact]
        public void should_return_4_when_unpark_all_car()
        {
            var parkingAreaA = new ParkingLot();

            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());

            parkingAreaA.UnAllPark();

            Assert.Equal((uint)4, parkingAreaA.remianParkingSpace());
        }
    }

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

    public class ParkingBoy {
        public ParkingBoy(ParkingLot parkingLot)
        {
            
        }

        public int Park(Car car)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ParkingLot {
        private const uint defaultCapacity = 4;
        private IList<Car> _carList;
        private uint _capacity;

        public ParkingLot()
        {
            _capacity = defaultCapacity;
            _carList = new List<Car>();
        }

        public int Park(Car car)
        {
            if (_capacity > 0)
            {
                _carList.Add(car);
                _capacity = _capacity - 1;
                return car.GetHashCode();
            }
            else
            {
                return 0;
            }
        }

        public Car Pick(int token)
        {
            foreach (var car in _carList)
            {
                if (car.GetHashCode().Equals(token))
                {
                    _carList.Remove(car);
                    _capacity++;
                    return car;
                }
            }
            return null;
        }

        public IList<Car> UnAllPark()
        {
            _capacity = defaultCapacity;
            return _carList;
        }

        public uint remianParkingSpace()
        {
            return _capacity;
        }
    }

    public class Car {}
}