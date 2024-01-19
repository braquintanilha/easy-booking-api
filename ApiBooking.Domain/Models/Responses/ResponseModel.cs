using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace ApiBooking.Domain.Models.Responses;

public class ResponseModel<T>
{
    public ResponseModel(T data)
    {
        Data = data;
    }

    public ResponseModel(string error)
    {
        Error = error;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Error { get; private set; }
}
