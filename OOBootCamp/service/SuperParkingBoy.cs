using System.Collections.Generic;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class SuperParkingBoy
    {
        private readonly IList<ParkingLot> parkingLots; 
        public SuperParkingBoy(IList<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public int Park(Car car)
        {
            return parkingLots[0].Park(car);
        }
    }
}