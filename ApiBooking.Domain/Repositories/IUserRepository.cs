namespace ApiBooking.Domain.Repositories;

public interface IUserRepository
{
    Task<bool> IsUserIdValid(int userId);
}
