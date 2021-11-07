using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string _model;
        public int _maxSpeed;
        public int _maxFlightDistance;
        public int _maxLoadCapacity;

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            _model = model;
            _maxSpeed = maxSpeed;
            _maxFlightDistance = maxFlightDistance;
            _maxLoadCapacity = maxLoadCapacity;
        }

        public string Model => _model;

        public int MaxSpeed => _maxSpeed;

        public int MaxFlightDistance => _maxFlightDistance;


        public int MaxLoadCapacity => _maxLoadCapacity;


        public override string ToString()
            => $"Plane{{model='{_model}\', maxSpeed={_maxSpeed}, maxFlightDistance={_maxFlightDistance}, maxLoadCapacity={_maxFlightDistance}}}";



        public override bool Equals(object obj)
            => obj is Plane plane &&
               (_model, _maxSpeed, _maxFlightDistance, _maxLoadCapacity) == (plane._model, plane._maxSpeed,
                   plane._maxFlightDistance, plane._maxLoadCapacity);

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode *= -1521134295 + EqualityComparer<string>.Default.GetHashCode(_model);
            hashCode *= -1521134295 + _maxSpeed.GetHashCode();
            hashCode *= -1521134295 + _maxFlightDistance.GetHashCode();
            hashCode *=  -1521134295 + _maxLoadCapacity.GetHashCode();
            return hashCode;
        }        

    }
}
