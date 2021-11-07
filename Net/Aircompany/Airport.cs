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

        public List<PassengerPlane> GetPassengersPlanes() => Planes.OfType<PassengerPlane>().ToList();


        public List<MilitaryPlane> GetMilitaryPlanes() => Planes.OfType<MilitaryPlane>().ToList();


        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
            => Planes.OfType<PassengerPlane>().MaxBy(plane => plane.PassengersCapacity);


        public List<MilitaryPlane> GetTransportMilitaryPlanes()
            => Planes.OfType<MilitaryPlane>().Where(plane => plane._type == MilitaryType.Transport).ToList();


        public Airport SortByMaxDistance()
            => new(Planes.OrderBy(w => w.MaxFlightDistance));

        public Airport SortByMaxSpeed()
            => new(Planes.OrderBy(w => w.MaxSpeed));


        public Airport SortByMaxLoadCapacity()
            => new(Planes.OrderBy(plane => plane.MAXLoadCapacity()));


        public IEnumerable<Plane> GetPlanes()
            => Planes;

        public override string ToString()
            => $"Airport{{planes={string.Join(", ", Planes.Select(x => x.Model))}}}";
    }

    
}
