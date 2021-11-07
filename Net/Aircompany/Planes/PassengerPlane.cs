using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public int _passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
            => _passengersCapacity = passengersCapacity;


        public override bool Equals(object obj)
            => obj is PassengerPlane plane && base.Equals(plane) && _passengersCapacity == plane._passengersCapacity;
           

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode *= -1521134295 + base.GetHashCode();
            hashCode *=  -1521134295 + _passengersCapacity.GetHashCode();
            return hashCode;
        }

        public int PassengersCapacity => _passengersCapacity;


        public override string ToString()
            => base.ToString().Replace("}", $", passengersCapacity={_passengersCapacity}}}");
     
        
    }
}
