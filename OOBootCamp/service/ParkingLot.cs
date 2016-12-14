using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Model;

namespace OOBootCamp.service
{
    public class ParkingLot {
        private const uint DefaultCapacity = 4;
        private readonly IList<Car> carList;
        private uint RemainCount { get; set; }
        private uint Capacity { get; set; }

        public ParkingLot(uint defaultcapacity = DefaultCapacity)
        {
            RemainCount = defaultcapacity;
            Capacity = defaultcapacity;
            carList = new List<Car>();
        }

        public int Park(Car car)
        {
            if (RemainCount > 0)
            {
                carList.Add(car);
                RemainCount = RemainCount - 1;
                return car.GetHashCode();
            }
            return 0;
        }

        public Car Pick(int token)
        {
            foreach (var car in carList.Where(car => car.GetHashCode().Equals(token))) {
                carList.Remove(car);
                RemainCount++;
                return car;
            }
            return null;
        }

        public IList<Car> UnAllPark()
        {
            RemainCount = DefaultCapacity;
            return carList;
        }

        public uint RemianParkingSpace()
        {
            return RemainCount;
        }

        public bool IsAvailable()
        {
            return RemainCount > 0;
        }

        public double GetVacancyRate()
        {
            return (double)RemainCount / (double)Capacity;
        }
    }
}