using System.Linq;

namespace OOBootCamp.service
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(ParkingLot[] parkingLotList) : base(parkingLotList) {}

        protected override ParkingLot GetParkingLot()
        {
            return ParkingLotList.FirstOrDefault(parkingLot => parkingLot.IsAvailable()) ?? ParkingLotList[0];
        }
    }
}