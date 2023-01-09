using System.Globalization;
using System.Text.RegularExpressions;

namespace Football_World_Cup_Score_Board_Test.BLL
{
    public class ParseTeamStringList
    {
        private readonly ILogger<ParseTeamStringList> _logger;
        public ParseTeamStringList(ILogger<ParseTeamStringList> logger)
        {
            _logger = logger;
        }


        public List<Teams> ParseStringList(List<string> currentDataList)
        {
            _logger.LogInformation("ParseStringList Medthod Called");
            List<Teams> teamsList = new List<Teams>();
            try
            {
                if (currentDataList.Count() > 0)
                {
                    int x = 1; //index counter
                    // List of strings to parse                
                    foreach (string input in currentDataList)
                    {

                        //create teams object to populate
                        Teams teams = new Teams();

                        //I did not add to constructor since it could be dyanmic in the future.
                        CultureInfo enCulture = CultureInfo.GetCultureInfo("en-US");
                        DateTime dateAdded = DateTime.Now;
                        string formattedTime = dateAdded.ToString("dd MMMM yyyy HH:mm:ss", enCulture);
                        teams.dateAdded = formattedTime;
                        teams.positionAdded = x; x++;
                        // delay for date 
                        Thread.Sleep(100); //The dates get added so quickly that need some delay to compare;

                        //The pattern came from https://chat.openai.com/chat
                        //This is a regular expression that defines a pattern for matching strings that represent a country name. The regular expression consists of the following parts:

                        //\b: This specifies a word boundary.
                        //[A - Z]: This matches any uppercase letter from A to Z.
                        //  [a - z] *: This matches zero or more lowercase letters from a to z.
                        //\b: This specifies another word boundary.
                        //The regular expression will match any string that begins and ends with a word boundary,
                        //and contains one or more uppercase letters followed by zero or more lowercase letters.
                        //For example, it would match "Canada", "United States", "Nepal", etc.,
                        //but it would not match "canada", "United", "nepal", etc.
                        string patternCountry = @"(\b[A-Z][a-z]*\b)";
                        // Attempt to match the regular expression to the input string
                        MatchCollection countryMatches = Regex.Matches(input, patternCountry);

                        if (countryMatches.Count == 2)
                        {
                            try
                            {
                               
                                teams.homeTeamName = countryMatches[0].Value;
                                teams.awayTeamName = countryMatches[1].Value;
                                _logger.LogTrace("Countries Successful from Regex");
                            }
                            catch(Exception ex)
                            { 
                                _logger.LogCritical("Method ParseStringList failed to Add Countries to Model", ex.Message, ex.InnerException);
                                
                            }
                        }
                        else
                        {
                            _logger.LogError("Method ParseStringList failed to Parse Countries");
                        }

                        //The pattern came from https://chat.openai.com/chat 
                        // Attempt to match the regular expression to the input string
                        MatchCollection matchesScores = Regex.Matches(input, @"\b\d+\b");
                        if (matchesScores.Count == 2)
                        {
                            try
                            {
                                teams.homeTeamScore = int.Parse(matchesScores[0].Value);
                                teams.awayTeamScore = int.Parse(matchesScores[1].Value);
                                _logger.LogTrace("Scores Successful from Regex");

                            }
                            catch (Exception ex)
                            {
                                _logger.LogCritical("Method ParseStringList failed to Add Scores", ex.Message, ex.InnerException);
                                
                            }

                        }
                        else
                        {
                            _logger.LogError("Method ParseStringList failed to Parse Scores");
                        }
                        //add teams collection to list
                        teamsList.Add(teams);
                    }
                }              

            }
            catch (System.Exception ex)
            {
                _logger.LogCritical("Method ParseStringList failed to Parse Scores", ex.Message, ex.InnerException);
               
            }
            return teamsList;
        }
    }
}
        
