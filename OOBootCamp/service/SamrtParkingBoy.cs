using System.Linq;

namespace OOBootCamp.service
{
    public class SamrtParkingBoy : ParkingBoyBase
    {
        public SamrtParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
            ParkAction = (car) => GetParkingLotWithMaxEmptySpaceCount().Park(car);
        }

        protected ParkingLot GetParkingLotWithMaxEmptySpaceCount()
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