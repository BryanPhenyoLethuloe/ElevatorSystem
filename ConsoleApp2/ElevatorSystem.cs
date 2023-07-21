using System;
using System.Collections.Generic;
using System.Linq;
using ElevatorSystem.Interfaces;
using ElevatorSystem.Models;

namespace ElevatorSystem
{
    public class ElevatorSystem : IElevatorSystem
    {
        private List<Elevator> elevators;
        private List<Floor> floors;

        public ElevatorSystem()
        {
            elevators = new List<Elevator>();
            floors = new List<Floor>();
        }
        // Implementation of the new method to get the list of elevators
        public List<Elevator> GetElevators()
        {
            return elevators;
        }
        public List<Floor> GetFloors()
        {
            return floors;
        }

        public void InitializeElevators(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Elevator elevator = new Elevator();
                elevators.Add(elevator);
            }
        }

        public void InitializeFloors(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Floor floor = new Floor(i + 1);
                floors.Add(floor);
            }
        }

        public void SetPeopleWaitingOnFloor(int floorNumber, int numberOfPeople)
        {
            Floor floor = floors.FirstOrDefault(f => f.FloorNumber == floorNumber);
            if (floor != null)
            {
                floor.NumberOfPeopleWaiting = numberOfPeople;
            }
        }

        public void MoveElevators()
        {
            foreach (Elevator elevator in elevators)
            {
                if (!elevator.IsMoving)
                {
                    Floor destinationFloor = floors.FirstOrDefault(f => f.NumberOfPeopleWaiting > 0);
                    if (destinationFloor != null)
                    {
                        Elevator nearestAvailableElevator = FindNearestAvailableElevator(destinationFloor);
                        if (nearestAvailableElevator != null)
                        {
                            nearestAvailableElevator.MoveToFloor(destinationFloor.FloorNumber);
                            nearestAvailableElevator.Disembark(destinationFloor);
                            nearestAvailableElevator.Embark(destinationFloor);
                        }
                    }
                }
            }
        }

        private Elevator FindNearestAvailableElevator(Floor floor)
        {
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (Elevator elevator in elevators)
            {
                if (!elevator.IsMoving)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - floor.FloorNumber);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestElevator = elevator;
                    }
                }
            }

            return nearestElevator;
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Elevator Status:");
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id}:");
                Console.WriteLine($"  Current Floor: {elevator.CurrentFloor}");
                Console.WriteLine($"  Direction: {elevator.Direction}");
                Console.WriteLine($"  Number of People: {elevator.NumberOfPeople}");
                Console.WriteLine();
            }

            Console.WriteLine("Floor Status:");
            foreach (var floor in floors)
            {
                Console.WriteLine($"Floor {floor.FloorNumber}: {floor.NumberOfPeopleWaiting} people waiting");
            }
        }
    }
}
