using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPaymentsProject.Domain.Utilities
{
    public class Result<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public AggregateException Exceptions { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(AggregateException errors) => new Result<T> { IsSuccess = false, Exceptions = errors };
    }
}
