using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingManager
    {
        private readonly ParkingBoy parkingBoy;
        private readonly SmartParkingBoy smartParkingBoy;

        public ParkingManager(ParkingBoy parkingBoy=null, SmartParkingBoy smartParkingBoy=null)
        {
            this.parkingBoy = parkingBoy;
            this.smartParkingBoy = smartParkingBoy;
        }

        public int SimplePark(Car car)
        {
            return parkingBoy.Park(car);
        }

        public int SmartPark(Car car)
        {
            return smartParkingBoy.Park(car);
        }
    }
}