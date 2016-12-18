using System.Collections.Generic;

namespace OOBootCamp.service
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(IList<ParkingLot> parkingLots) : base(parkingLots)
        {
            ParkAction = (car) => GetParkingLotWithHighestVcancyRate().Park(car);
        }

        protected ParkingLot GetParkingLotWithHighestVcancyRate()
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