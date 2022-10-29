using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private DataStruct stateOfGame;
    void Start()
    {
        FirstRunApp.SetUp();
        stateOfGame = SaveManager.Load();
    }

    public void SetHighScore(int newHS)
    {
        if (newHS > stateOfGame.highscore)
        {
            stateOfGame.highscore = newHS;
        }
        SaveManager.Save(stateOfGame);
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
}
