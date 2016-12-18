﻿using OOBootCamp.Model;
using OOBootCamp.service;
using Xunit;

namespace OOBootCamp.test
{
    public class ParkingManagerTest
    {
        [Fact]
        public void should_ask_parking_boy_park_one_car_to_first_available_parking_lot()
        {
            var secondParkingLot = new ParkingLot(3);
            var firstParkingLot = new ParkingLot(5);
            var parkingBoy = new ParkingBoy(new[] {firstParkingLot, secondParkingLot});
            var parkingManager = new ParkingManager(parkingBoy);

            var car = new Car();
            var carToken = parkingManager.SimplePark(car);

            Assert.Same(car,firstParkingLot.Pick(carToken));
        }

        [Fact]
        public void should_ask_smart_parking_boy_park_one_car_to_parking_lot_with_most_empty_parking_space()
        {
        }

        [Fact]
        public void should_ask_super_parking_boy_park_one_car_to_parking_lot_with_highest_vacancy_rate()
        {
            
        }

        [Fact]
        public void should_ask_any_parking_boy_pick_one_car_successfully()
        {
            
        }

        [Fact]
        public void should_park_one_car_by_himself()
        {
            
        }

        [Fact]
        public void should_park_car_failed_while_no_park_space_by_himself()
        {
            
        }

        [Fact]
        public void should_pick_one_car_successfully_by_himself()
        {
            
        }

        [Fact]
        public void should_pick_car_failed_by_himself()
        {
            
        }
    }
}