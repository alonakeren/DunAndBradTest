using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DunBrad
{
    //[RoutePrefix("api")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]

    public class AgentController : ApiController
    {
        private AgentLogic logic = new AgentLogic();

        [HttpGet]
        [Route("agents")]
        public HttpResponseMessage GetAllAgents()
        {
            try
            {
                List<AgentModel> agents = logic.GetAllAgents();
                return Request.CreateResponse(HttpStatusCode.OK, agents);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}