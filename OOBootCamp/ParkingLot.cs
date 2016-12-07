using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp
{
    public class ParkingLot {
        private const uint DefaultCapacity = 4;
        private readonly IList<Car> carList;
        private uint capacity;

        public ParkingLot()
        {
            capacity = DefaultCapacity;
            carList = new List<Car>();
        }

        public int Park(Car car)
        {
            if (capacity > 0)
            {
                carList.Add(car);
                capacity = capacity - 1;
                return car.GetHashCode();
            }
            else
            {
                return 0;
            }
        }

        public Car Pick(int token)
        {
            foreach (var car in carList.Where(car => car.GetHashCode().Equals(token))) {
                carList.Remove(car);
                capacity++;
                return car;
            }
            return null;
        }

        public IList<Car> UnAllPark()
        {
            capacity = DefaultCapacity;
            return carList;
        }

        public uint RemianParkingSpace()
        {
            return capacity;
        }
    }
}