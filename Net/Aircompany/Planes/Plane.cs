namespace Aircompany.Planes
{
    public abstract class Plane
    {
        private readonly string _model;
        private readonly int _maxSpeed;
        private readonly int _maxFlightDistance;
        private readonly int _maxLoadCapacity;

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
               (_model, _maxSpeed, _maxFlightDistance, _maxLoadCapacity) == (plane._model, plane._maxSpeed, plane._maxFlightDistance, plane._maxLoadCapacity);

        public override int GetHashCode() => HashCode.Combine(_model, _maxSpeed, _maxFlightDistance, _maxLoadCapacity);
      

    }
}
