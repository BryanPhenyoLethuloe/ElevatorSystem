﻿using ElevatorSystem.Models;

namespace ElevatorSystem.Interfaces
{
    public interface IElevatorSystem
    {
        void InitializeElevators(int count);
        void InitializeFloors(int count);
        void SetPeopleWaitingOnFloor(int floorNumber, int numberOfPeople);
        void MoveElevators();
        void DisplayStatus();
        List<Elevator> GetElevators();
        List<Floor> GetFloors();

    }
}
