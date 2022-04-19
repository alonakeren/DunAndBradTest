using System.Collections.Generic;
using System.Linq;

namespace DunBrad
{
    public class AgentLogic : BaseLogic
    {
        public List<AgentModel> GetAllAgents()
        {
            var query = from a in DB.AGENTS
                        select new AgentModel
                        {
                            AGENT_CODE = a.AGENT_CODE,
                            AGENT_NAME = a.AGENT_NAME,
                            WORKING_AREA = a.WORKING_AREA,
                            COMMISSION = a.COMMISSION,
                            PHONE_NO = a.PHONE_NO,
                            COUNTRY = a.COUNTRY
                        };
            return query.ToList();
        }
    }
}

