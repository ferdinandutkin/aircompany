using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private readonly MilitaryType _type;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity) => _type = type;
 
        public override bool Equals(object obj)
            => obj is MilitaryPlane plane && base.Equals(plane) && _type == plane._type;
        
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), _type);

        public MilitaryType Type => _type;

        public override string ToString()
            => base.ToString().Replace("}", $", type={_type}}}");
    }
}
