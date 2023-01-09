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


        public HomeController(ILogger<HomeController> logger, ILogger<ImportTeamData> importTeamDataLogger)
        {
            _logger = logger;
            _importTeamDataLogger = importTeamDataLogger;
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
            HomeViewModel model = new HomeViewModel();
           
            try
            {
                
                ImportTeamData importTeamData = new ImportTeamData(_importTeamDataLogger);
                List<string> teamDataList = importTeamData.getTeamDataList();




            }
            catch (Exception)
            {

                throw;
            }
                



            return PartialView("_DisplayScores", model);
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