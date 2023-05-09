using System.Collections.Generic;

namespace videoPortal.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
