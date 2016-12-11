using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class SamrtParkingBoy {
        private readonly ParkingLot[] parkingLots;

        public SamrtParkingBoy(ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public int Park(Car car)
        {
            return GetParkingLotWithMoreParkingSpace().Park(car);
        }

        private ParkingLot GetParkingLotWithMoreParkingSpace()
        {
            var maxSpaceParkingLot = parkingLots[0];
            foreach (var parkingLot in parkingLots.Where(parkingLot => parkingLot.RemianParkingSpace() > maxSpaceParkingLot.RemianParkingSpace())) {
                maxSpaceParkingLot = parkingLot;
            }
            return maxSpaceParkingLot;
        }
    }
}