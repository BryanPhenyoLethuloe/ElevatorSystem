using ElevatorSystem.Interfaces;
using NUnit.Framework;

namespace ElevatorSystem.Tests
{
    [TestFixture]
    public class ElevatorSystemTests
    {
        [Test]
        public void TestElevatorMovement()
        {
            // Arrange
            IElevatorSystem elevatorSystem = new ElevatorSystem();
            elevatorSystem.InitializeElevators(1);
            elevatorSystem.InitializeFloors(5);

            // Act
            elevatorSystem.SetPeopleWaitingOnFloor(1, 2); // Set 2 people waiting on floor 1
            elevatorSystem.SetPeopleWaitingOnFloor(3, 3); // Set 3 people waiting on floor 3
            elevatorSystem.MoveElevators();

            // Assert
            // Add appropriate assertions here to check if elevators moved as expected
        }

        [Test]
        public void TestElevatorEmbarkDisembark()
        {
            // Arrange
            IElevatorSystem elevatorSystem = new ElevatorSystem();
            elevatorSystem.InitializeElevators(1);
            elevatorSystem.InitializeFloors(5);

            // Act
            elevatorSystem.SetPeopleWaitingOnFloor(1, 8); // Set 8 people waiting on floor 1
            elevatorSystem.MoveElevators();

            // Assert
            // Add appropriate assertions here to check if elevators embarked and disembarked passengers as expected
        }
    }
}
