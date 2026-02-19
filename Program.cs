class Program
{
    static async Task Main(string[] args)
    {
        var apiService = new FootballApiService();
        var processor = new HistoricalDataProcessor();

        //string json = await apiService.GetLastFiveMatches("TEAM_ID");

        string json = File.ReadAllText("C:/Users/MTC-ADM/Documents/Projects2026/MainDemo/mockDtata.json");

        //Console.WriteLine(json);

        var matches = processor.ExtractMatchStats(json);

        var matchStats = new MatchStats { HomeTeam = "", AwayTeam = "" };

        foreach (var match in matches)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Date: {match.MatchDate:yyyy-MM-dd}");
            Console.WriteLine();
            Console.WriteLine($"Home Team : {match.HomeTeam}");
            Console.WriteLine($"Goals     : {match.HomeGoals}");
            Console.WriteLine($"Corners   : {match.HomeCorners}");
            Console.WriteLine();
            Console.WriteLine($"Away Team : {match.AwayTeam}");
            Console.WriteLine($"Goals     : {match.AwayGoals}");
            Console.WriteLine($"Corners   : {match.AwayCorners}");
            Console.WriteLine("=================================\n");
        }

    }
}
