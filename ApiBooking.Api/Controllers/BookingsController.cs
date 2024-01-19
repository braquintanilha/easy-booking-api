using ApiBooking.Domain;
using ApiBooking.Domain.Entities;
using ApiBooking.Domain.Models.Requests;
using ApiBooking.Domain.Models.Responses;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ApiBooking.Api.Controllers;

[Route("v1/api/bookings")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IValidator<CreateBookingRequest> _validator;

    public BookingsController(IBookingService bookingService, IValidator<CreateBookingRequest> validator)
    {
        _bookingService = bookingService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllBookings();
        var bookingResponses = bookings.Select(booking => (BookingResponse)booking).ToList();

        return Ok(new ResponseModel<List<BookingResponse>>(bookingResponses));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking([FromRoute] int id)
    {
        var booking = await _bookingService.GetBooking(id);

        if (booking == null)
            return NotFound(new ResponseModel<string>("Booking not found"));

        return Ok(new ResponseModel<BookingResponse>((BookingResponse)booking));
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> CreateBooking([FromBody] CreateBookingRequest request)
    {
        var result = await _validator.ValidateAsync(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        var booking = new Booking(request);

        var createdBooking = await _bookingService.CreateBooking(booking);

        if (createdBooking == null)
            return StatusCode(500, new ResponseModel<string>("Internal Server Error"));

        return Created(nameof(GetBooking), new ResponseModel<Booking>(createdBooking));
    }

    [HttpPatch("confirm/{id}")]
    public async Task<ActionResult<Booking>> ConfirmBooking([FromRoute] int id)
    {
        var booking = await _bookingService.GetBooking(id);

        if (booking == null)
            return NotFound(new ResponseModel<string>("Booking not found"));

        if (booking.Status == Domain.Enums.BookingStatus.Confirmed ||
            booking.Status == Domain.Enums.BookingStatus.Cancelled)
            return UnprocessableEntity(new ResponseModel<string>($"The booking status is {booking.Status}"));

        var confirmedBooking = await _bookingService.ConfirmBooking(booking);

        if (confirmedBooking == null)
            return StatusCode(500, new ResponseModel<string>("Internal Server Error"));

        return confirmedBooking;
    }

    [HttpPatch("cancel/{id}")]
    public async Task<ActionResult<Booking>> CancelBooking([FromRoute] int id)
    {
         var booking = await _bookingService.GetBooking(id);

        if (booking == null)
            return NotFound(new ResponseModel<string>("Booking not found"));

        var cancelledBooking = await _bookingService.CancelBooking(booking);

        if (cancelledBooking == null)
            return StatusCode(500, new ResponseModel<string>("Internal Server Error"));

        return cancelledBooking;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Booking>> DeleteBooking(int id)
    {
        var deletedBooking = await _bookingService.DeleteBooking(id);
        if (deletedBooking == null)
        {
            return NotFound();
        }

        return deletedBooking;
    }
}
