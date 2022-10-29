using UnityEngine;


public enum Tile
{
    UpSpike,
    DownSpike,
    UpCoin,
    DownCoin,
    Default
}

public static class LevelGenerator
{
    public static int startOffset, endOffset = 10;

    public static Tile[] GeneratrLevel(int duration)
    {
        Tile[] level = new Tile[startOffset + duration + endOffset];
        for (int i = 0; i < startOffset; i++)
        {
            level[i] = Tile.Default;
        }

        // Main part of lvl

        for (int i = 0; i < duration; i++)
        {
            int chance = Random.Range(0, 4);
            switch (chance)
            {
                case 0:
                    level[startOffset + i] = Tile.Default;
                    break;
                case 1:
                    level[startOffset + i] = Tile.UpCoin;
                    break;
                case 2:
                    level[startOffset + i] = Tile.DownCoin;
                    break;
                case 3:
                    if (level[startOffset + i - 1] != Tile.DownSpike)
                    {
                        level[startOffset + i] = Tile.UpSpike;
                    }
                    else
                    {
                        level[startOffset + i] = Tile.Default;
                    }
                    break;
                case 4:
                    if (level[startOffset + i - 1] != Tile.UpSpike)
                    {
                        level[startOffset + i] = Tile.DownSpike;
                    }
                    else
                    {
                        level[startOffset + i] = Tile.Default;
                    }
                    break;
                default:
                    Debug.LogError("Random is broken");
                    break;
            }
        }
        // end generating main part

        for (int i = 0; i < endOffset; i++)
        {
            level[startOffset + duration + i] = Tile.Default;
        }
        return level;
    }
}
