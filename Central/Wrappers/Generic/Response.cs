using System.Net;

namespace Central.Wrappers.Generic;


// API-lar Response olaraq her 1i, mueyyen edilmis standart ile cavab qaytarmalidir
public class Response<T>
{
    public Response()
    {
    }

    public Response(T data, string message = null)
    {
        IsSucceeded = true;
        StatusCode = HttpStatusCode.OK;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        IsSucceeded = false;
        StatusCode = HttpStatusCode.BadRequest;
        Message = message;
    }

    public Response(string message, IEnumerable<string> errors)
    {
        IsSucceeded = false;
        StatusCode = HttpStatusCode.BadRequest;
        Message = message;
        Errors = [];
        Errors.AddRange(errors);
    }

    public Response(T data, string message, IEnumerable<string> errors)
    {
        IsSucceeded = false;
        StatusCode = HttpStatusCode.BadRequest;
        Message = message;
        Errors = [];
        Errors.AddRange(errors);
        Data = data;
    }

    public bool IsSucceeded { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }


    public static Response<T> Success(T data, string message)
        => new()
        {
            IsSucceeded = true,
            StatusCode = HttpStatusCode.OK,
            Message = message,
            Data = data,
            Errors = []
        };

    public static Response<T> Success(string message)
        => new()
        {
            IsSucceeded = true,
            StatusCode = HttpStatusCode.OK,
            Message = message,
            Errors = []
        };

    public static Response<T> Success()
        => new()
        {
            IsSucceeded = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Ugurlu emeliyyat",
            Errors = []
        };

    public static Response<T> Fail(HttpStatusCode statusCode, string message, IEnumerable<string> errors = null)
        => new()
        {
            IsSucceeded = false,
            StatusCode = statusCode,
            Message = message,
            Errors = errors?.ToList() ?? [],
            Data = default
        };

    public static Response<T> Fail(HttpStatusCode statusCode, string message, T data, IEnumerable<string> errors = null)
        => new()
        {
            IsSucceeded = false,
            StatusCode = statusCode,
            Message = message,
            Errors = errors?.ToList() ?? [],
            Data = data
        };
}
