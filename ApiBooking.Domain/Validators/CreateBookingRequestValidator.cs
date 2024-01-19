using ApiBooking.Domain.Models.Requests;
using FluentValidation;

namespace ApiBooking.Domain.Validators;

public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
{
    public CreateBookingRequestValidator()
    {
        RuleFor(x => x.CheckInDt)
                .NotEmpty().WithMessage("Check-in date is required.");

            RuleFor(x => x.CheckOutDt)
                .NotEmpty().WithMessage("Check-out date is required.");

            RuleFor(x => x.NumberOfGuests)
                .NotEmpty().WithMessage("Number of guests is required.")
                .GreaterThanOrEqualTo(1).WithMessage("Number of guests must be at least 1.");

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("Total price is required.")
                .GreaterThan(0).WithMessage("Total price must be greater than 0.");

            RuleFor(x => x.HotelId)
                .NotEmpty().WithMessage("Hotel ID is required.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
    }
}
