using System;

namespace Proj3_Khan.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string Message { get; internal set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    }
}
