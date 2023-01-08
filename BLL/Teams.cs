using System.ComponentModel.DataAnnotations;

namespace Football_World_Cup_Score_Board_Test.BLL
{

    //Added to the BLL leve since it's not a view model
    public class Teams
    {

        public string dateAdded { get; set; } // I wanted the extended date for comparing.
        public string homeTeamName { get; set; }
        public string awayTeamName { get; set; }
        public int homeTeamScore { get; set; }
        public int awayTeamScore { get; set; }
        [Key]
        public int positionAdded { get; set; }
    }
}
