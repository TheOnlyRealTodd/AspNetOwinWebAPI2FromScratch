using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auth2.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        //This Checks for the dynamically created role based upon user claims, entitled IncidentResolvers.
        [Authorize(Roles = "IncidentResolvers")]
        [HttpPut]
        [Route("refund/{orderId}")]
        public IHttpActionResult RefundOrder([FromUri]string orderId)
        {
            return Ok();
        }
    }
}
