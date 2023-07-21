using NUnit.Framework;
using ElevatorSystem.Interfaces;
using ElevatorSystem.Models;

namespace ElevatorSystem.Tests
{
    [TestFixture]
    public class ElevatorSystemTests
    {
        [Test]
        public void ElevatorSystem_InitializeElevators_ShouldCreateElevatorsWithCorrectCount()
        {
            // Arrange
            IElevatorSystem elevatorSystem = new ElevatorSystem();
            int expectedElevatorCount = 2;

            // Act
            elevatorSystem.InitializeElevators(expectedElevatorCount);

            // Assert
            Assert.AreEqual(expectedElevatorCount, elevatorSystem.GetElevators().Count);
        }

        [Test]
        public void ElevatorSystem_InitializeFloors_ShouldCreateFloorsWithCorrectCount()
        {
            // Arrange
            IElevatorSystem elevatorSystem = new ElevatorSystem();
            int expectedFloorCount = 5;

            // Act
            elevatorSystem.InitializeFloors(expectedFloorCount);

            // Assert
            Assert.AreEqual(expectedFloorCount, elevatorSystem.GetFloors().Count);
        }

        [Test]
        public void ElevatorSystem_SetPeopleWaitingOnFloor_ShouldSetCorrectNumberOfPeople()
        {
            // Arrange
            IElevatorSystem elevatorSystem = new ElevatorSystem();
            elevatorSystem.InitializeFloors(5);
            int floorNumber = 1;
            int numberOfPeople = 3;

            // Act
            elevatorSystem.SetPeopleWaitingOnFloor(floorNumber, numberOfPeople);

            // Assert
            Assert.AreEqual(numberOfPeople, elevatorSystem.GetFloors()[floorNumber - 1].NumberOfPeopleWaiting);
        }

        [Test]
        public void Elevator_MoveToFloor_ShouldMoveElevatorToCorrectFloor()
        {
            // Arrange
            Elevator elevator = new Elevator();
            int initialFloor = 1;
            int destinationFloor = 3;

            // Act
            elevator.MoveToFloor(destinationFloor);

            // Assert
            Assert.AreEqual(destinationFloor, elevator.CurrentFloor);
        }

        [Test]
        public void Elevator_Embark_ShouldIncreaseNumberOfPeopleInElevator()
        {
            // Arrange
            Elevator elevator = new Elevator();
            Floor floor = new Floor(1);
            int numberOfPeople = 2;
            floor.NumberOfPeopleWaiting = numberOfPeople;

            // Act
            elevator.Embark(floor);

            // Assert
            Assert.AreEqual(numberOfPeople, elevator.NumberOfPeople);
            Assert.AreEqual(0, floor.NumberOfPeopleWaiting);
        }

      
    }
}
