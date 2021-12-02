using System.Collections.Generic;
using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
      
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.PlanesTestData))]
        public void TransportMilitaryPlanes_ReturnsOnlyTransportMilitatyPlanes(List<Plane> planes)
        {
            var airport = new Airport(planes);
            Assert.That(airport.TransportMilitaryPlanes, Has.All.Property(nameof(MilitaryPlane.Type)).EqualTo(MilitaryType.Transport));
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.PlanesTestData))]
        public void MilitaryPlanes_ReturnsOnlyMilitatyPlanes(List<Plane> planes)
        {
            var airport = new Airport(planes);
            Assert.That(airport.MilitaryPlanes, Has.All.TypeOf<MilitaryPlane>());
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.PlanesTestData))]
        public void PassengersPlanes_ReturnsOnlyPassangersPlanes(List<Plane> planes)
        {
            var airport = new Airport(planes);
            Assert.That(airport.PassengersPlanes, Has.All.TypeOf<PassengerPlane>());
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetPassengerPlaneWithMaxPassengersCapacityTestData))]
        public void GetPassengerPlaneWithMaxPassengersCapacity_ReturnsExpectedValue(List<Plane> planes, Plane expected)
        {
            var airport = new Airport(planes);
            var actual = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.AreEqual(actual, expected);
        }
      
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.PlanesTestData))]
        public void SortByMaxLoadCapacity_ReturnsListSortedByMaxLoadCapacity(List<Plane> planes)
        {
            var airport = new Airport(planes).SortByMaxLoadCapacity();
            Assert.That(airport.Planes, Is.Ordered.By(nameof(Plane.MaxLoadCapacity)));
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.PlanesTestData))]
        public void SortByMaxSpeed_ReturnsListSortedByMaxSpeed(List<Plane> planes)
        {
            var airport = new Airport(planes).SortByMaxSpeed();
            Assert.That(airport.Planes, Is.Ordered.By(nameof(Plane.MaxSpeed)));
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.PlanesTestData))]
        public void SortByMaxFlightDistance_ReturnsListSortedByMaxFlightDistance(List<Plane> planes)
        {
            var airport = new Airport(planes).SortByMaxFlightDistance();
            Assert.That(airport.Planes, Is.Ordered.By(nameof(Plane.MaxFlightDistance)));
        }
    }
}