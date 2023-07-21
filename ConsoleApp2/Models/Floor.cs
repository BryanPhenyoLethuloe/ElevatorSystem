namespace ElevatorSystem.Models
{
    public class Floor
    {
        public int FloorNumber { get; private set; }
        public int NumberOfPeopleWaiting { get; set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            NumberOfPeopleWaiting = 0;
        }
    }
}
