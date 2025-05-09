using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Data.Results
{
    public sealed class ResultServices
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public object? _Entity { get; set; }
    }
}
