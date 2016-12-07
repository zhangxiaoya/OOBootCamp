using System.Linq;
using OOBootCamp.test;

namespace OOBootCamp.service
{
    public class ParkingBoy {
        private readonly ParkingLot[] parkingLotList;

        public ParkingBoy(ParkingLot[] parkingLotList)
        {
            this.parkingLotList = parkingLotList;
        }

        public int Park(Car car)
        {
            return (from parkingLot in parkingLotList where parkingLot.IsAvailable() select parkingLot.Park(car)).FirstOrDefault();
        }

        public Car Pick(int token)
        {
            return parkingLotList[0].Pick(token);
        }
    }
}