using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingLot {
        private const uint DefaultCapacity = 4;
        private readonly IList<Car> carList;
        private uint Capacity { get; set; }

        public ParkingLot(uint defaultCapacity = DefaultCapacity)
        {
            Capacity = defaultCapacity;
            carList = new List<Car>();
        }

        public int Park(Car car)
        {
            if (Capacity > 0)
            {
                carList.Add(car);
                Capacity = Capacity - 1;
                return car.GetHashCode();
            }
            return 0;
        }

        public Car Pick(int token)
        {
            foreach (var car in carList.Where(car => car.GetHashCode().Equals(token))) {
                carList.Remove(car);
                Capacity++;
                return car;
            }
            return null;
        }

        public IList<Car> UnAllPark()
        {
            Capacity = DefaultCapacity;
            return carList;
        }

        public uint RemianParkingSpace()
        {
            return Capacity;
        }

        public bool IsAvailable()
        {
            return Capacity > 0;
        }
    }
}