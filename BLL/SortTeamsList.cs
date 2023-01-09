namespace Football_World_Cup_Score_Board_Test.BLL
{
    public class SortTeamsList
    {
        private readonly ILogger<SortTeamsList> _logger;
        public SortTeamsList(ILogger<SortTeamsList> logger)
        {
            _logger = logger;
        }

        public List<Teams> ReOrder(List<Teams> teamsList)
        {
            _logger.LogInformation("ReOrder Medthod Called");
            //The list should look like
            //            The summary would provide with the following information: 
            //1.Uruguay 6 - Italy 6
            ////2.Spain 10 - Brazil 2
            //3.Mexico 0 - Canada 5
            //4.Argentina 3 - Australia 1
            //5.Germany 2 - France
            var sortedTeams = new List<Teams>();
            try
            {
                 sortedTeams = teamsList.OrderByDescending(g => g.awayTeamScore == g.homeTeamScore)
                                   .ThenByDescending(g => g.dateAdded)
                                   .ToList();
                if(sortedTeams.Any())
                {
                    _logger.LogTrace("ReOrder Medthod CalledCompleted");


                }
                else
                {
                    _logger.LogError("ReOrder Medthod Failed to Sort List");
                }

            }
            catch (Exception ex)
            {
                _logger.LogCritical("ReOrder Medthod Caused an Exception",ex.Message, ex.InnerException);

            }

            //return the sorted Teams back to controller
            return sortedTeams;
        }
    }
}

