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
            return GetParkingLotWithHighVacancyRate().Park(car);
        }

        private ParkingLot GetParkingLotWithHighVacancyRate()
        {
            var parkingPotWithHighVacancyRate = parkingLots[0];
            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.GetVacancyRate() > parkingPotWithHighVacancyRate.GetVacancyRate())
                {
                    parkingPotWithHighVacancyRate = parkingLot;
                }
            }
            return parkingPotWithHighVacancyRate;
        }
    }
}