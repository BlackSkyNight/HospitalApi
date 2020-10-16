using System;
using System.Threading.Tasks;

namespace DAL
{
    internal class Result<TResult> : IResult<TResult> 
    {
        public TResult Data { get; protected set; }
        public bool Status { get; }

        public Result(TResult data) 
        {
            this.Data = data;
            this.Status = data != null;
        }
    }

    public class Result
    {
        public static IResult<T> From<T>(T data)
        {
            return new Result<T>(data);
        }

        public async static Task<IResult<T>> From<T>(Task<T> solver)
        {
            return new Result<T>(await solver);
        }
    }
}
