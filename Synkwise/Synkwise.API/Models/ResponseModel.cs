using System.Net;

namespace Synkwise.API.Models
{
    public class ResponseModel
    {
        public object Status { get; set; } = HttpStatusCode.OK;

        public object Message { get; set; }

        public string Token { get; set; }
    }
}
