using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class SamrtParkingBoy : ParkingBoyBase
    {
        public SamrtParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public int Park(Car car)
        {
            return GetParkingLotWithMoreParkingSpace().Park(car);
        }

        private ParkingLot GetParkingLotWithMoreParkingSpace()
        {
            var maxSpaceParkingLot = ParkingLotList[0];
            foreach (var parkingLot in ParkingLotList.Where(parkingLot => parkingLot.RemianParkingSpace() > maxSpaceParkingLot.RemianParkingSpace()))
            {
                maxSpaceParkingLot = parkingLot;
            }
            return maxSpaceParkingLot;
        }
    }
}