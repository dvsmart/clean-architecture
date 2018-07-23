using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Response
{
    public abstract class ResponseBase
    {
        public bool SaveSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
