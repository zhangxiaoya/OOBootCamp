﻿using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_park_one_car()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(new[]{parkingLot});

            var car = new Car();
            var token = parkingBoy.Park(car);

            Assert.Same(car,parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_one_car_to_first_avaliable_parking_lot()
        {
            var parkingLotOne = new ParkingLot();
            var parkingLotTwo = new ParkingLot();
            var parkingBoy = new ParkingBoy(new[]{parkingLotOne,parkingLotTwo});

            TakeAllParkingSpaceOfParkingLotOne(parkingLotOne);

            var car = new Car();
            var token = parkingBoy.Park(car);

            Assert.Same(car, parkingLotTwo.Pick(token));
        }

        [Fact]
        public void should_pick_one_car()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(new[] { parkingLot});

            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickCar = parkingBoy.Pick(token);
            Assert.Same(car, pickCar);
        }

        private static void TakeAllParkingSpaceOfParkingLotOne(ParkingLot parkingLot1)
        {
            parkingLot1.Park(new Car());
            parkingLot1.Park(new Car());
            parkingLot1.Park(new Car());
            parkingLot1.Park(new Car());
        }
    }
}