using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace GetMock.Functions
{
    public static class GetWithQuery
    {
        [FunctionName(nameof(GetWithQuery))]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "query/entity")]HttpRequestMessage req)
        {
            // parse query parameter
            var id = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "id", StringComparison.OrdinalIgnoreCase) == 0)
                                                 .Value;

            return id == null ? req.CreateResponse(HttpStatusCode.BadRequest, "Please provide id on the query string") 
                              : req.CreateResponse(HttpStatusCode.OK, new Payload{ Id = id });
        }
    }
}
