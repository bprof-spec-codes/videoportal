using System;

namespace videoPortal.Responses
{
    public class CreatePlayListSuccessResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string UserName { get; set; }

        public string Playtime { get; set; }
    }
}