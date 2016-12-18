using System.Linq;

namespace OOBootCamp.service
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
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