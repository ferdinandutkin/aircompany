using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType _type;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _type = type;
        }

        public override bool Equals(object obj)
            => obj is MilitaryPlane plane && base.Equals(plane) && _type == plane._type;
        

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode *=  -1521134295 + base.GetHashCode();
            hashCode *= -1521134295 + _type.GetHashCode();
            return hashCode;
        }

        public MilitaryType PlaneType => _type;


        public override string ToString()
            => base.ToString().Replace("}", $", type={_type}}}");
    }
}
