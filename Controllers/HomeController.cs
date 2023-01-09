using Football_World_Cup_Score_Board_Test.BLL;
using Football_World_Cup_Score_Board_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace Football_World_Cup_Score_Board_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogger<ImportTeamData> _importTeamDataLogger;
        private readonly ILogger<ParseTeamStringList> _parseTeamStringListLogger;
        private readonly ILogger<SortTeamsList> _sortTeamsListLogger;


        public HomeController(ILogger<HomeController> logger, ILogger<ImportTeamData> importTeamDataLogger, ILogger<ParseTeamStringList> parseTeamStringListLogger, ILogger<SortTeamsList> sortTeamsListLogger)
        {
            _logger = logger;
            _importTeamDataLogger = importTeamDataLogger;
            _parseTeamStringListLogger = parseTeamStringListLogger;
            _sortTeamsListLogger = sortTeamsListLogger;

        }

        public IActionResult Index()
        {
            Teams teams = new Teams();
            try
            {
                teams.awayTeamName = "Away team";
                teams.awayTeamScore = 0;
                teams.homeTeamName = "Home team";
                teams.positionAdded = 1;

            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trying to create Teams Object", ex.Message, ex.InnerException);
            }

            //Add new Teams to a list
            List<Teams> teamsList = new List<Teams>();
            teamsList.Add(teams);

            //create Model for View
            HomeViewModel model = new HomeViewModel();
            model.teamsList = teamsList;

            return View("Index", model);


        }

        [HttpPost]
        public ActionResult GetScores()
        {
            HomeViewModel viewModel = new HomeViewModel();
            List<string> teamDataList = new List<string>();
            List<Teams> teamsList = new List<Teams>();
            List<Teams> sortedTeams = new List<Teams>();


            try
            {

                ImportTeamData importTeamData = new ImportTeamData(_importTeamDataLogger);
                teamDataList = importTeamData.getTeamDataList();

                if (teamDataList.Count > 0)
                {
                    //success
                    _logger.LogTrace("ImportTeamData populated the list correctly");
                    try
                    {
                        //Use StringList of Raw data to pupulate Teams Collection
                        ParseTeamStringList parseCurrentData = new ParseTeamStringList(_parseTeamStringListLogger);
                        teamsList = parseCurrentData.ParseStringList(teamDataList);

                        //Add to Model for Partial

                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical("Parsing TeamStringList Caused an Exception", ex.Message, ex.InnerException);

                    }
                }
                if (teamsList.Count > 0)
                {
                    //Need to Sort List for View

                    try
                    {
                        SortTeamsList organizeList = new SortTeamsList(_sortTeamsListLogger);
                        sortedTeams = organizeList.ReOrder(teamsList);
                        if (sortedTeams.Count > 0)
                        {
                            viewModel.teamsList = sortedTeams;
                        }
                        else
                        {
                            _logger.LogError("Sorted list is empty");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical("Sorting The TeamList has failed", ex.Message, ex.InnerException);
                    }
                }
                else
                {
                    //This will cause the issue moving forward
                    _logger.LogError("ImportTeamData list is empty");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("ImportTeamData Caused an Exception", ex.Message, ex.InnerException);
            }

            return PartialView("_DisplayScores", viewModel);
        }



        [HttpPost]
        public ActionResult HandleJavaScriptError(string error)
        {
            // Log the error message

            _logger.LogCritical("An error occurred in JavaScript: " + error);

            // You can also return a view or redirect to a different URL here
            return Json(new { success = true });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}