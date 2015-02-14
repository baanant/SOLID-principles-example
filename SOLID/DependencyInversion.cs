using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DepencencyInverionPrinciple
{

    /// Dependency inversion principle means that one should depend upon abstraction, not upon concretions. 
    /// For example in this case, the class Driver takes abstraction IVehicle as a constructor parameter.
    public interface IVehicle
    {
        string Drive();
    }

    public class Car : IVehicle
    {

        public string Drive()
        {
            return "Driving with my car.";
        }
    }

    public class Bike : IVehicle
    {
        public string Drive()
        {
            return "Driving with my bike.";
        }
    }

    public class Driver
    {
        IVehicle vehicle;

        public Driver() { }

        //Constructor injection.
        public Driver(IVehicle v)
        {
            vehicle = v;
        }

        //Method injection.
        public void SetVehicle(IVehicle v)
        {
            vehicle = v;
        }

        public string BeginJourney()
        {
            return vehicle.Drive();
        }

    }


    ///This example violate's the Dependecy inversion principle. Both bike and car requires their own begin journey methods, and constructor requires
    ///two parameters, just in case because we don't know which specific vehicle the driver decides to take for a journey. 
    public class Driver2 
    {

        Bike bike;
        Car car;
        public Driver2(Bike b, Car c)
        {
            bike = b;
            car = c;
        }

        public string BeginJourneyWithBike()
        {
            return bike.Drive();
        }

        public string BeginJourneyWithCar()
        {
            return car.Drive();
        }

    }

}
