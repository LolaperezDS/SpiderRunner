using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private DataStruct stateOfGame;
    public int currentScore = 0;
    private int constDifficuilt = 10;
    public bool isPlying = true;
    void Start()
    {
        Application.targetFrameRate = 120;
        FirstRunApp.SetUp();
        stateOfGame = SaveManager.Load();
        GetComponent<LevelInstantinater>().InstantinateLevel();
    }

    public void SetHighScore(int newHS)
    {
        if (newHS > stateOfGame.highscore)
        {
            stateOfGame.highscore = newHS;
            SaveManager.Save(stateOfGame);
        }
    }

    public bool PossibilityToSpend(int cost)
    {
        if (stateOfGame.gold > cost && cost > 0)
        {
            return true;
        }
        return false;
    }

    public void Spend(int cost)
    {
        stateOfGame.gold -= cost;
        SaveManager.Save(stateOfGame);
    }

    public int GetGold()
    {
        return stateOfGame.gold;
    }

    public int GetHighScore()
    {
        return stateOfGame.highscore;
    }

    public float GetSpeed()
    {
        return Mathf.Sqrt((currentScore + 1) * constDifficuilt);
    }

    public int GetLengthOfLevel()
    {
        return Mathf.RoundToInt(Mathf.Sqrt(currentScore + 1) * constDifficuilt);
    }

    public void IncrementCurrentScore()
    {
        currentScore += 1;
    }

    public void IncrementGold()
    {
        stateOfGame.gold += 1;
        SaveManager.Save(stateOfGame);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
