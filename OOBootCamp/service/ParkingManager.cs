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
            return parkingBoy == null ? 0 : parkingBoy.Park(car);
        }

        public int SmartPark(Car car)
        {
            return smartParkingBoy == null ? 0 : smartParkingBoy.Park(car);
        }

        public int SuperPark(Car car)
        {
            return superParkingBoy == null ? 0 : superParkingBoy.Park(car);
        }

        public Car Pick(int carToken)
        {
            var pickedByParkingBoy = parkingBoy.Pick(carToken);
            var pickedBySmartParkingBoy = smartParkingBoy.Pick(carToken);
            var pickedBySuperParkingBoy = superParkingBoy.Pick(carToken);
            if (pickedByParkingBoy == null)
            {
                if (pickedBySmartParkingBoy == null)
                {
                    return pickedBySuperParkingBoy;
                }
                return pickedBySmartParkingBoy;
            }
            return pickedByParkingBoy;
        }
    }
}