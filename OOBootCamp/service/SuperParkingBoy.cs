using System.Collections.Generic;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(IList<ParkingLot> parkingLots) :base(parkingLots)
        {
        }

        public int Park(Car car)
        {
            return GetParkingLotWithHighVacancyRate().Park(car);
        }

        private ParkingLot GetParkingLotWithHighVacancyRate()
        {
            var parkingPotWithHighVacancyRate = ParkingLotList[0];
            foreach (var parkingLot in ParkingLotList)
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