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
    public static int startOffset = 30;
    public static int endOffset = 30;
    public static int xOrigin = -20;

    public static Tile[] GeneratrLevel(int duration)
    {
        Tile[] level = new Tile[startOffset + (int)(1.5 * duration) + endOffset];
        for (int i = 0; i < startOffset + (int)(duration / 2); i++)
        {
            level[i] = Tile.Default;
        }

        // Main part of lvl

        for (int i = 0; i < duration; i++)
        {
            int chance = Random.Range(0, 5);
            ref Tile curent_tile = ref level[startOffset + (int)(duration / 2) + i];
            switch (chance)
            {
                case 0:
                    curent_tile = Tile.Default;
                    break;
                case 1:
                    curent_tile = Tile.UpCoin;
                    break;
                case 2:
                    curent_tile = Tile.DownCoin;
                    break;
                case 3:
                    if (level[startOffset + (int)(duration / 2) + i - 1] != Tile.DownSpike)
                    {
                        curent_tile = Tile.UpSpike;
                    }
                    else
                    {
                        curent_tile = Tile.Default;
                    }
                    break;
                case 4:
                    if (level[startOffset + (int)(duration / 2) + i - 1] != Tile.UpSpike)
                    {
                        curent_tile = Tile.DownSpike;
                    }
                    else
                    {
                        curent_tile = Tile.Default;
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
            level[startOffset + (int)(duration / 2) + duration + i] = Tile.Default;
        }
        return level;
    }
}
