using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace GetMock.Functions
{
    public static class GetWithRest
    {
        [FunctionName(nameof(GetWithRest))]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rest/entity/{id}")]HttpRequestMessage req, string id)
        {
            return req.CreateResponse(HttpStatusCode.OK, new Payload { Id = id });
        }
    }
}
