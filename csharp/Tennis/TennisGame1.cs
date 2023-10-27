using System.Collections.Generic;
using System.Linq;

namespace Tennis;

public class TennisGame1 : ITennisGame
{
    private readonly Player _firstPlayer;
    private readonly Player _secondPlayer;

    public TennisGame1(string player1Name, string player2Name)
    {
        _firstPlayer = new Player(player1Name);
        _secondPlayer = new Player(player2Name);
    }

    public void WonPoint(string playerName)
    {
        var player = GetPlayerByName(playerName);

        if (player == null) return;

        player.Points += 1;
    }

    public string GetGameResult()
    {
        string score = "";
        int tempScore = 0;

        var pointsFromFirstPlayer = _firstPlayer.Points;
        

        if (_firstPlayer.Points == _secondPlayer.Points)
        {
            
            score = GetEqualScoreDescription(_firstPlayer.Points);
        }
        else if (m_score1 >= 4 || m_score2 >= 4)
        {
            var minusResult = m_score1 - m_score2;
            
            CheckIfPlayerHasWon(minusResult);
            
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";

        }
        else
        {
            for (int i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    tempScore = m_score1;
                }
                else
                {
                    score += "-";
                    tempScore = m_score2;
                }

                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }
        }

        return score;
    }

    private bool CheckIfPlayerHasWon(object minusResult)
    {
        
        
        
        return 
    }

    private static string GetEqualScoreDescription(int score)
    {
        string scoreDescription = score switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };

        return scoreDescription;
    }

    private Player? GetPlayerByName(string name)
    {
        return _players.FirstOrDefault(player => player.Name == name);
    }
}