using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IResult<TData>
    {
        bool Status { get; }
        TData Data { get; }
    }
}
