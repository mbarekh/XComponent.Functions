using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using XComponent.Functions.Core;
using XComponent.Functions.Core.Exceptions;

namespace XComponent.Functions.Controllers
{
    public class RessourceController: ApiController
    {
        [SwaggerResponse(HttpStatusCode.OK, "Available ressource", typeof(FunctionParameter))]
        [SwaggerResponse(HttpStatusCode.NoContent, "No ressource available")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid request")]
        public HttpResponseMessage GetRessource()
        {
            try
            {
                var response = FunctionsFactory.Instance.GetKeyValuePairs();
                return Request.CreateResponse(response == null ? HttpStatusCode.NoContent : HttpStatusCode.OK, response);
            }
            catch (ValidationException ve)
            {
                return Request.CreateResponse<ValidationException>(HttpStatusCode.BadRequest, ve);
            }
        }

    }
}
