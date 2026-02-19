using System.Text.Json;
public class HistoricalDataProcessor
{
    public List<MatchStats> ExtractMatchStats(string json)
    {
        var matches = new List<MatchStats>();

        using JsonDocument doc = JsonDocument.Parse(json);
        var fixtures = doc.RootElement.GetProperty("response");

        foreach (var fixture in fixtures.EnumerateArray())
        {
            var match = new MatchStats
            {
                MatchDate = fixture.GetProperty("fixture")
                                .GetProperty("date")
                                .GetDateTime(),

                HomeTeam = fixture.GetProperty("teams")
                                .GetProperty("home")
                                .GetProperty("name")
                                .GetString() ?? string.Empty,

                AwayTeam = fixture.GetProperty("teams")
                                .GetProperty("away")
                                .GetProperty("name")
                                .GetString() ?? string.Empty,

                HomeGoals = fixture.GetProperty("goals")
                                .GetProperty("home")
                                .GetInt32(),

                AwayGoals = fixture.GetProperty("goals")
                                .GetProperty("away")
                                .GetInt32()
            };

            // Extract corners
            var statsArray = fixture.GetProperty("statistics");

            foreach (var teamStats in statsArray.EnumerateArray())
            {
                var teamName = teamStats.GetProperty("team")
                                        .GetProperty("name")
                                        .GetString();

                foreach (var stat in teamStats.GetProperty("statistics").EnumerateArray())
                {
                    if (stat.GetProperty("type").GetString() == "Corner Kicks")
                    {
                        int corners = stat.GetProperty("value").GetInt32();

                        if (teamName == match.HomeTeam)
                            match.HomeCorners = corners;
                        else if (teamName == match.AwayTeam)
                            match.AwayCorners = corners;
                    }
                }
            }

            matches.Add(match);
        }

        return matches;
    }

}
