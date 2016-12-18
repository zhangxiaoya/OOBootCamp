using System.Linq;

namespace OOBootCamp.service
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(ParkingLot[] parkingLotList) : base(parkingLotList)
        {
            ParkAction = (car) => GetFirstAvailableParkingLot().Park(car);
        }

        protected ParkingLot GetFirstAvailableParkingLot()
        {
            return ParkingLotList.FirstOrDefault(parkingLot => parkingLot.IsAvailable()) ?? ParkingLotList[0];
        }
    }
}