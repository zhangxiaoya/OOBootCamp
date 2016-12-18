using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingManager
    {
        private readonly ParkingBoy parkingBoy;
        private readonly SmartParkingBoy smartParkingBoy;
        private readonly SuperParkingBoy superParkingBoy;

        public ParkingManager(ParkingBoy parkingBoy = null, SmartParkingBoy smartParkingBoy = null, SuperParkingBoy superParkingBoy = null)
        {
            this.parkingBoy = parkingBoy;
            this.smartParkingBoy = smartParkingBoy;
            this.superParkingBoy = superParkingBoy;
        }

        public int SimplePark(Car car)
        {
            return parkingBoy.Park(car);
        }

        public int SmartPark(Car car)
        {
            return smartParkingBoy.Park(car);
        }

        public int SuperPark(Car car)
        {
            return superParkingBoy.Park(car);
        }
    }
}