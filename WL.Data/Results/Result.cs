using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Data.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public T? Value { get; }

        private Result(bool isSuccess, T? value, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);

        public static Result<T> Failure(string error) => new Result<T>(false, default, error);
    }
}
