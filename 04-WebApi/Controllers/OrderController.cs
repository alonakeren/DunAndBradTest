using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DunBrad
{
    public class OrderController : ApiController
    {
        private OrderLogic logic = new OrderLogic();

        [HttpGet]
        [Route("orders")]
        public HttpResponseMessage GetAllOrders()
        {
            try
            {
                List<OrderModel> orders = logic.GetAllOrders();
                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //--1
        [HttpGet]
        [Route("orders/{yearOrd}")]
        public HttpResponseMessage GetSumAgentCode(int yearOrd)
        {
            try
            {
                List<GetSumAgentCodeByYear_Result> orders = logic.GetSumAgentCode(yearOrd);
                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // --2
        [HttpGet]
        [Route("orders/{agentCodeList}/{rownumentered}")]
        public HttpResponseMessage GetAgentCodeByRowNumber(string agentCodeList, int rownumentered)
        {
            try
            {
                // remove whitespaces in the list of agentCodeList
                agentCodeList = agentCodeList.Replace(" ", "");

                // count rows in ORDERS table to put in as parameter in stored procedure "TOP rowsCount"
                int rowsCount = logic.GetCountRows();

                List<GetAgentCodeByRowNumber_Result> orders = logic.GetAgentCodeByRowNumber(rowsCount, agentCodeList, rownumentered);
                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //--3
        [HttpGet]
        [Route("agents/{numentered}/{yearentered}")]
        public HttpResponseMessage GetAgentsByQtyOrders(int numentered, int yearentered)
        {
            try
            {
                List<GetAgentsByQtyOrders_Result> orders = logic.GetAgentsByQtyOrders(numentered, yearentered);
                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            logic.Dispose();
        }
    }
}