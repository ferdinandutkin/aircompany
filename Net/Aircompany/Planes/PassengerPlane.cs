namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private readonly int _passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
            => _passengersCapacity = passengersCapacity;


        public override bool Equals(object obj)
            => obj is PassengerPlane plane && base.Equals(plane) && _passengersCapacity == plane._passengersCapacity;


        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), _passengersCapacity);
     
        public int PassengersCapacity => _passengersCapacity;


        public override string ToString()
            => base.ToString().Replace("}", $", passengersCapacity={_passengersCapacity}}}");
     
        
    }
}
