namespace OOBootCamp
{
    public class ParkingBoy {
        private readonly ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public int Park(Car car)
        {
            return parkingLot.Park(car);
        }
    }
}