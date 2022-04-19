using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DunBrad
{
    public class OrderLogic : BaseLogic
    {
        public List<OrderModel> GetAllOrders()
        {
            var query = from o in DB.ORDERS
                        select new OrderModel
                        {
                            ORD_NUM = o.ORD_NUM,
                            ORD_AMOUNT = o.ORD_AMOUNT,
                            ADVANCE_AMOUNT = o.ADVANCE_AMOUNT,
                            ORD_DATE = o.ORD_DATE,
                            CUST_CODE = o.CUST_CODE,
                            AGENT_CODE = o.AGENT_CODE,
                            ORD_DESCRIPTION = o.ORD_DESCRIPTION
                        };
            return query.ToList();
        }

        public List<GetSumAgentCodeByYear_Result> GetSumAgentCode(int yearOrd)
        {
            List<GetSumAgentCodeByYear_Result> result = new List<GetSumAgentCodeByYear_Result>();

            using (var context = new DunBEntities())
            {
                var yearParam = new SqlParameter("@ORD_DATE", yearOrd);

                result = context.Database
                    .SqlQuery<GetSumAgentCodeByYear_Result>("GetSumAgentCodeByYear @ORD_DATE", yearParam)
                    .ToList();
            }

            return result;
        }

        public List<GetAgentCodeByRowNumber_Result> GetAgentCodeByRowNumber(int rowCount, string agentCodeList, int rownumentered)
        {
            List<GetAgentCodeByRowNumber_Result> result = new List<GetAgentCodeByRowNumber_Result>();

            using (var context = new DunBEntities())
            {
                var rowCountParam = new SqlParameter("@Top_Rows_Count", rowCount);
                var agentParam = new SqlParameter("@AGENT_CODE_list", agentCodeList);
                var rowParam = new SqlParameter("@Rownumentered", rownumentered);

                object[] parameters = { rowCountParam, agentParam, rowParam };

                result = context.Database
                    .SqlQuery<GetAgentCodeByRowNumber_Result>("GetAgentCodeByRowNumber @Top_Rows_Count, @AGENT_CODE_list, @Rownumentered", parameters)
                    .ToList();
            }

            return result;
        }

        public List<GetAgentsByQtyOrders_Result> GetAgentsByQtyOrders(int numentered, int yearentered)
        {
            List<GetAgentsByQtyOrders_Result> result = new List<GetAgentsByQtyOrders_Result>();

            using (var context = new DunBEntities())
            {
                var numParam = new SqlParameter("@Numentered", numentered);
                var yearParam = new SqlParameter("@Yearentered", yearentered);

                object[] parameters = { numParam, yearParam };

                result = context.Database
                    .SqlQuery<GetAgentsByQtyOrders_Result>("GetAgentsByQtyOrders @Numentered, @Yearentered", parameters)
                    .ToList();
            }

            return result;
        }

        public int GetCountRows()
        {
            int rowCount = 0;

            using (var context = new DunBEntities())
            {
                rowCount = context.ORDERS
            .Count();
            }
            return rowCount;
        }
    }
}

