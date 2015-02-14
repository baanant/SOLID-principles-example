using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.InterfaceSegregationPrinciple
{

    /// Interface segregation principle means that many client-specific interfaces are better than one multipurpose interface.
    /// The following example is an example of this.
    public interface IVehicle
    {
        string Name { get; set; }

        string Description { get; set; }

    }

    public interface IBike:IVehicle
    {
        int NoOfWheels { get; set; }
    }

    public interface IBoat:IVehicle
    {
        string BoatTypeDescription { get; set; }
    }


    /// This example violate's the Interface segregation principle, because if we now want to create a class Boat which would inherit 
    /// the interface IVehicles, it would have to implement also the property NoOfWheels, which has nothing to do with the basic concept of a boat.
    public interface IVehicles
    {
        string Name { get; set; }

        string Description { get; set; }

        string BoatTypeDescription { get; set; }

        int NoOfWheels { get; set; }
    }

}
