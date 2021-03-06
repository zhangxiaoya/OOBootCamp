﻿using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_park_and_pick_one_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(4);

            var token = parkingLot.Park(car);

            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_pick_the_right_one_when_park_two_car()
        {
            var car1 = new Car();
            var car2 = new Car();
            var parkingLot = new ParkingLot(4);

            var token = parkingLot.Park(car1);
            parkingLot.Park(car2);

            Assert.Same(car1, parkingLot.Pick(token));
        }

        [Fact]
        public void should_not_pick_one_car_twice()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(4);

            var token = parkingLot.Park(car);

            Assert.Same(car,parkingLot.Pick(token));
            Assert.Null(parkingLot.Pick(car.GetHashCode()));
        }

        [Fact]
        public void should_not_park_when_parklot_is_full()
        {
            var parkingLot = new ParkingLot(4);
            var invalidToekn = 0;

            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            var parkToken = parkingLot.Park(new Car());

            Assert.Equal(invalidToekn,parkToken);
        }

        [Fact]
        public void should_be_false_when_parking_lot_is_available()
        {
            var parkingLot = new ParkingLot(4);

            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());

            Assert.False(parkingLot.IsAvailable());
        }

        [Fact]
        public void should_be_true_when_parking_lot_is_available()
        {
            var parkingLot = new ParkingLot(4);

            parkingLot.Park(new Car());

            Assert.True(parkingLot.IsAvailable());
        }

        [Fact]
        public void should_return_remain_parking_space()
        {
            var car = new Car();

            var parkingAreaA = new ParkingLot(4);
            parkingAreaA.Park(car);

            Assert.Equal((uint)3, parkingAreaA.RemianParkingSpace());
        }

        [Fact]
        public void should_return_4_when_no_car_parking()
        {
            var parkingAreaA = new ParkingLot(4);

            Assert.Equal((uint)4, parkingAreaA.RemianParkingSpace());
        }

        [Fact]
        public void should_return_0_when_4_cars_parking()
        {
            var parkingAreaA = new ParkingLot(4);

            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());

            Assert.Equal((uint)0, parkingAreaA.RemianParkingSpace());
        }

        [Fact]
        public void should_return_0_and_last_car_can_not_parking_when_5_cars_parking()
        {
            var parkingAreaA = new ParkingLot(4);

            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            parkingAreaA.Park(new Car());
            var lastCarParkingStatus = parkingAreaA.Park(new Car());

            Assert.Equal(lastCarParkingStatus,0);

            Assert.Equal((uint)0, parkingAreaA.RemianParkingSpace());
        }

        [Fact]
        public void should_return_3_when_parking_2_cars_and_unparking_1_car()
        {
            var parkingAreaA = new ParkingLot(4);

            var car = new Car();
            parkingAreaA.Park(car);
            parkingAreaA.Park(new Car());

            parkingAreaA.Pick(car.GetHashCode());

            Assert.Equal((uint)3, parkingAreaA.RemianParkingSpace());
        }

    }
}