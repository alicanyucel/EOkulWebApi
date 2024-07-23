using System.Text.Json.Serialization;

namespace eOkulServer.Domain.Abstracts;
public sealed record Result<T>
{
    public Result(T data)
    {
        Data = data;
    }

    public Result(List<string> errorMessages, int statusCode = 400)
    {
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
        IsSuccessful = false;
    }

    public Result(bool isSuccessful, string errorMessage, int statusCode = 400)
    {
        StatusCode = statusCode;
        ErrorMessages = new() { errorMessage };
        IsSuccessful = false;
    }

    public Result(bool isSuccessful, List<string> errorMessages, int statusCode = 400)
    {
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
        IsSuccessful = false;
    }
    public T? Data { get; set; }
    public bool IsSuccessful { get; set; } = true;
    public List<string>? ErrorMessages { get; set; }
    [JsonIgnore]
    public int StatusCode { get; set; } = 200;

    public static Result<T> Success(T data)
    {
        return new Result<T>(data);
    }

    public static Result<T> Failure(string errorMessage, int statusCode = 400)
    {
        return new Result<T>(false, errorMessage, statusCode);
    }

    public static Result<T> Failure(List<string> errorMessages, int statusCode = 400)
    {
        return new Result<T>(false, errorMessages, statusCode);
    }

    public static implicit operator Result<T>(T data)
    {
        return new Result<T>(data);
    }
}
