public class MatchStats
{
    public DateTime MatchDate { get; set; }

    public string? HomeTeam { get; set; }
    public string? AwayTeam { get; set; }

    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }

    public int HomeCorners { get; set; }
    public int AwayCorners { get; set; }

    // public int TotalGoalsScored(List<MatchStats> matches)
    //     => matches.Sum(m => m.GoalsScored);

    // public int TotalGoalsConceded(List<MatchStats> matches)
    //     => matches.Sum(m => m.GoalsConceded);

    // public double AverageCorners(List<MatchStats> matches)
    //     => matches.Average(m => m.CornersFor);
}
