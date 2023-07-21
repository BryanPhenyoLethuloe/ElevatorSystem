using System;
using System.Drawing;
using ElevatorSystem.Enums;

namespace ElevatorSystem.Models
{
    public class Elevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public bool IsMoving { get; private set; }
        public Direction Direction { get; private set; }
        public int NumberOfPeople { get; private set; }
        public int TotalWeight { get; private set; }
        private const int WeightLimit = 10; // Weight limit in number of people

        public Elevator()
        {
            Id = Guid.NewGuid().GetHashCode(); // Unique ID for each elevator
            CurrentFloor = 1; // Default starting floor
            IsMoving = false;
            Direction = Direction.Stationary;
            NumberOfPeople = 0;
            TotalWeight = 0; // Initialize the total weight to zero
        }

        public void MoveToFloor(int floorNumber)
        {
            if (floorNumber > CurrentFloor)
            {
                Direction = Direction.Up;
            }
            else if (floorNumber < CurrentFloor)
            {
                Direction = Direction.Down;
            }

            IsMoving = true;
            while (CurrentFloor != floorNumber)
            {
                if (Direction == Direction.Up)
                {
                    CurrentFloor++;
                }
                else if (Direction == Direction.Down)
                {
                    CurrentFloor--;
                }
            }
            IsMoving = false;
        }

        public void Embark(Floor floor)
        {
            int availableSpace = WeightLimit - NumberOfPeople;
            int availableWeight = WeightLimit - TotalWeight;

            if (floor.NumberOfPeopleWaiting <= availableSpace && availableWeight > 0)
            {
                int actualEmbarkCount = Math.Min(floor.NumberOfPeopleWaiting, availableWeight);
                NumberOfPeople += actualEmbarkCount;
                floor.NumberOfPeopleWaiting -= actualEmbarkCount;
                TotalWeight += actualEmbarkCount;
            }
            else
            {
                // Cannot embark more people due to weight limit or available space
            
            }
        }

        public void Disembark(Floor floor)
        {
            floor.NumberOfPeopleWaiting += NumberOfPeople;
            TotalWeight -= NumberOfPeople;
            NumberOfPeople = 0;
        }
    }
}
