﻿using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public abstract class ParkingBoyBase {
        protected readonly ParkingLot[] ParkingLotList;

        protected ParkingBoyBase(IList<ParkingLot> parkingLotList)
        {
            ParkingLotList = parkingLotList.ToArray();
        }

        public Car Pick(int token)
        {
            return ParkingLotList.Select(parkingLot => parkingLot.Pick(token)).FirstOrDefault(pickCar => pickCar != null);
        }

        public int Park(Car car)
        {
            return GetParkingLot().Park(car);
        }

        protected abstract ParkingLot GetParkingLot();
    }
}