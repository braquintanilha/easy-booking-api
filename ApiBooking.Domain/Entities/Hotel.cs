namespace ApiBooking.Domain.Entities;

public class Hotel
{
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public int TotalRooms { get; private set; }
    public int AvailableRooms { get; private set; }
}
