using Football_World_Cup_Score_Board_Test.BLL;

namespace Football_World_Cup_Score_Board_Test.Models
{
    public class HomeViewModel
    {
        //This List is for the Index View
        public List<Teams> teamsList { get; set; }

        public HomeViewModel()
        {
            //initialize List
            teamsList = new List<Teams>();
        }
    }
}
