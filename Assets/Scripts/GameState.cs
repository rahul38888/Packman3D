using UnityEngine;

public class GameState : MonoBehaviour
{
    private GhostState ghostsState = GhostState.CHASE;
    private int lifes = 4;
    private int score = 0;
    private bool gameOn = true;

    public void GhostsState(GhostState state)
    {
        ghostsState = state;
    }

    public GhostState GhostsState()
    {
        return ghostsState;
    }

    public void AddScore(int delta)
    {
       score += delta;
    }

    public int Score()
    {
        return score;
    }

    public void ReduceLife(int delta)
    {
        if (lifes - delta < 0)
        {
            lifes = 0;
        }
        else
        {
            lifes -= delta;
        }
    }
    public void ReduceLife()
    {
        ReduceLife(1);
    }

    public int Lifes()
    {
        return lifes;
    }

    public bool IsGameOn()
    {
        return gameOn;
    }

    public void GameOn(bool state)
    {
        gameOn = state;
    }

    public bool GameToggle()
    {
        gameOn = !gameOn;
        return gameOn;
    }
}
