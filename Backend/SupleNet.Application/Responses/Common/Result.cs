using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SupleNet.Application.Responses.Common
{
    public class Result<T>
    {
        private Result(bool isSuccess, string? message, T? data, HttpStatusCode httpStatusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            HttpStatusCode = httpStatusCode;
        }

        public static Result<T> Success(T? data, string? message, HttpStatusCode httpStatusCode)
        {
            return new Result<T>(true, message, data, httpStatusCode);
        }

        public static Result<T> Failed(string? message, HttpStatusCode httpStatusCode)
        {
            return new Result<T>(false, message, default, httpStatusCode);
        }

        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
