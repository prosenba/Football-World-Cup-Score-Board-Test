using Football_World_Cup_Score_Board_Test.Controllers;
using Microsoft.Extensions.Logging;

namespace Football_World_Cup_Score_Board_Test.BLL
{
    public  class ImportTeamData
    {
        private readonly ILogger<ImportTeamData> _importTeamDataLogger;               
        public ImportTeamData(ILogger<ImportTeamData> logger)
        {
            _importTeamDataLogger = logger;
        }

       private List<string> currentDataList = new List<string>();
        public List<string> getTeamDataList()
        {          
            _importTeamDataLogger.LogInformation("getTeamDataList method called");
            //current data in the system
            try
            {
                currentDataList.Add("a.Mexico - Canada: 0 - 5");
                currentDataList.Add("b.Spain - Brazil: 10 – 2");
                currentDataList.Add("c.Germany - France: 2 – 2");
                currentDataList.Add("d.Uruguay - Italy: 6 – 6");
                currentDataList.Add("e.Argentina - Australia: 3 - 1");
            }
            catch (Exception ex)
            {

                _importTeamDataLogger.LogCritical("Exception trying to add strings to List in getTeamDataList() ", ex.Message, ex.InnerException);
            }

            _importTeamDataLogger.LogInformation("getTeamDataList method completed");
            return currentDataList;

        }
    }
}
