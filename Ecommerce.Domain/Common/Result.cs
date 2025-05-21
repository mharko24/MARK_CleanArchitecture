
using Ecommerce.Domain.Exception;

namespace Ecommerce.Domain.Common
{
    public class Result<T> where T : class
    {
        private Result(bool isSucess, Error error, T data)
        {
            if (isSucess && error != Error.None ||
                !isSucess && error == Error.None)
            {
                throw new ArgumentException("Invalid Error", nameof(error));
            }

            IsSucess = isSucess;
            Error = error;
            Data = data;
        }

        public bool IsSucess { get; }
        public bool IsFailure => !IsSucess;
        public T Data { get; }

        public Error Error { get; }
        public static Result<T> Success(T data) //=> new(true, Error.None, T data);
        {
            return new Result<T>(true, Error.None, data);

        }
        public static Result<T> Failure(Error error) //=> new Result<T>(false, error, data);
        {
            return new Result<T>(false, error, null);
        }
    }
}
