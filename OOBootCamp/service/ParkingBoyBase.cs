using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingBoyBase {
        protected readonly ParkingLot[] ParkingLotList;

        public ParkingBoyBase(IList<ParkingLot> parkingLotList)
        {
            ParkingLotList = parkingLotList as ParkingLot[];
        }

        public Car Pick(int token)
        {
            return ParkingLotList.Select(parkingLot => parkingLot.Pick(token)).FirstOrDefault(pickCar => pickCar != null);
        }
    }
}