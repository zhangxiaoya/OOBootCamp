using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingManager
    {
        private readonly ParkingBoy parkingBoy;
        public ParkingManager(ParkingBoy parkingBoy)
        {
            this.parkingBoy = parkingBoy;
        }

        public int SimplePark(Car car)
        {
            return parkingBoy.Park(car);
        }
    }
}