using System.Collections.Generic;
using System.Linq;
using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private static readonly PassengerPlane PlaneWithMaxPassengerCapacity = new("Boeing-747", 980, 16100, 70500, 242);

        private static readonly List<Plane> Planes = new()
        {
            new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
            new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
            PlaneWithMaxPassengerCapacity,
            new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
            new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
            new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
            new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
            new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
            new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.Bomber),
            new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.Bomber),
            new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.Bomber),
            new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.Fighter),
            new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.Fighter),
            new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.Transport)
        };


        [Test]
        public void GetTransportMilitaryPlanes_IsNotEmpty()
        {
            var airport = new Airport(Planes);
            Assert.IsNotEmpty(airport.GetTransportMilitaryPlanes());
        }

        [Test]
        public void GetPassengerPlaneWithMaxPassengersCapacity_ReturnsExpectedValue()
        {
            var airport = new Airport(Planes);
            var actualPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.AreEqual(PlaneWithMaxPassengerCapacity, actualPlaneWithMaxPassengersCapacity);
        }

        [Test]
        public void SortByMaxLoadCapacity_ReturnsListSortedByMaxLoadCapacity()
        {
            var airport = new Airport(Planes);
            airport = airport.SortByMaxLoadCapacity();
            var planesSortedByMaxLoadCapacity = airport.Planes.ToList();

            var nextPlaneMaxLoadCapacityIsHigherThanCurrent = true;
            for (var i = 0; i < planesSortedByMaxLoadCapacity.Count - 1; i++)
            {
                var currentPlane = planesSortedByMaxLoadCapacity[i];
                var nextPlane = planesSortedByMaxLoadCapacity[i + 1];
                if (currentPlane.MaxLoadCapacity > nextPlane.MaxLoadCapacity)
                    nextPlaneMaxLoadCapacityIsHigherThanCurrent = false;
            }

            Assert.That(nextPlaneMaxLoadCapacityIsHigherThanCurrent);
        }
    }
}