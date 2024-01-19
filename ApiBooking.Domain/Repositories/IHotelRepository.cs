namespace ApiBooking.Domain.Repositories;

public interface IHotelRepository
{
    Task<bool> IsHotelIdValid(int hotelId);
    
}
