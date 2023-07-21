using System;
using ElevatorSystem.Interfaces;

namespace ElevatorSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating the elevator system with 2 elevators and 5 floors
            IElevatorSystem elevatorSystem = new ElevatorSystem();
            elevatorSystem.InitializeElevators(2);
            elevatorSystem.InitializeFloors(5);

            // Simulating user interactions
            Console.WriteLine("Welcome to the Elevator System!");
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Set the number of people waiting on a floor");
                Console.WriteLine("2. Call an elevator");
                Console.WriteLine("3. Move elevators and display status");
                Console.WriteLine("4. Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            SetPeopleWaitingOnFloor(elevatorSystem);
                            break;
                        case 2:
                            CallElevator(elevatorSystem);
                            break;
                        case 3:
                            elevatorSystem.MoveElevators();
                            elevatorSystem.DisplayStatus();
                            break;
                        case 4:
                            Console.WriteLine("Exiting the Elevator System. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void SetPeopleWaitingOnFloor(IElevatorSystem elevatorSystem)
        {
            Console.Write("Enter the floor number (1 to 5): ");
            if (int.TryParse(Console.ReadLine(), out int floorNumber))
            {
                if (floorNumber >= 1 && floorNumber <= 5)
                {
                    Console.Write("Enter the number of people waiting on the floor: ");
                    if (int.TryParse(Console.ReadLine(), out int numberOfPeople))
                    {
                        elevatorSystem.SetPeopleWaitingOnFloor(floorNumber, numberOfPeople);
                        Console.WriteLine($"People waiting on Floor {floorNumber} set to {numberOfPeople}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Number of people must be an integer.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid floor number. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Floor number must be an integer.");
            }
        }

        static void CallElevator(IElevatorSystem elevatorSystem)
        {
            Console.Write("Enter the floor number to call the elevator (1 to 5): ");
            if (int.TryParse(Console.ReadLine(), out int floorNumber))
            {
                if (floorNumber >= 1 && floorNumber <= 5)
                {
                    // You can add additional logic here to handle elevator calls based on user inputs
                    // For example, finding the nearest available elevator to the requested floor.
                    Console.WriteLine($"Calling elevator to Floor {floorNumber}.");
                }
                else
                {
                    Console.WriteLine("Invalid floor number. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Floor number must be an integer.");
            }
        }
    }
}
