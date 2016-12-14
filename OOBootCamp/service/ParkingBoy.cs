using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingBoy : ParkingBoyBase{
        public ParkingBoy(ParkingLot[] parkingLotList):base(parkingLotList)
        {
        }
        public int Park(Car car)
        {
            return (from parkingLot in ParkingLotList where parkingLot.IsAvailable() select parkingLot.Park(car)).FirstOrDefault();
        }
    }
}