using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> PassengersPlanes => Planes.OfType<PassengerPlane>().ToList();


        public List<MilitaryPlane> MilitaryPlanes => Planes.OfType<MilitaryPlane>().ToList();


        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
            => Planes.OfType<PassengerPlane>().MaxBy(plane => plane.PassengersCapacity);


        public List<MilitaryPlane> TransportMilitaryPlanes =>
            Planes.OfType<MilitaryPlane>().Where(plane => plane._type == MilitaryType.Transport).ToList();


        public Airport SortByMaxDistance()
            => new(Planes.OrderBy(w => w.MaxFlightDistance));

        public Airport SortByMaxSpeed()
            => new(Planes.OrderBy(w => w.MaxSpeed));


        public Airport SortByMaxLoadCapacity()
            => new(Planes.OrderBy(plane => plane.MaxLoadCapacity));


        public IEnumerable<Plane> GetPlanes()
            => Planes;

        public override string ToString()
            => $"Airport{{planes={string.Join(", ", Planes.Select(x => x.Model))}}}";
    }

    
}
