using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Domain
{
    public class Message
    {
        public string? Content { get; set; }
        public bool HasError { get; set; }

        public Message(string? content, bool hasError)
        {
            Content = content;
            HasError = hasError;
        }
    }
}
