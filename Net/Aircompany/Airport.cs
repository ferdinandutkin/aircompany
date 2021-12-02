using Aircompany.Models;
using Aircompany.Planes;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; private set; }

        public Airport(IEnumerable<Plane> planes)
            => Planes = planes.ToList();
   
        public List<PassengerPlane> PassengersPlanes => Planes.OfType<PassengerPlane>().ToList();

        public List<MilitaryPlane> MilitaryPlanes => Planes.OfType<MilitaryPlane>().ToList();

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
            => Planes.OfType<PassengerPlane>().MaxBy(plane => plane.PassengersCapacity);

        public List<MilitaryPlane> TransportMilitaryPlanes =>
            Planes.OfType<MilitaryPlane>().Where(plane => plane.Type == MilitaryType.Transport).ToList();

        public Airport SortByMaxFlightDistance()
            => new(Planes.OrderBy(w => w.MaxFlightDistance));

        public Airport SortByMaxSpeed()
            => new(Planes.OrderBy(w => w.MaxSpeed));

        public Airport SortByMaxLoadCapacity()
            => new(Planes.OrderBy(plane => plane.MaxLoadCapacity));

        public override string ToString()
            => $"Airport{{planes={string.Join(", ", Planes.Select(x => x.Model))}}}";
    }

    
}
