using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    [SerializeField] private GameObject TileDefaultP;
    [SerializeField] private GameObject TileSUP;
    [SerializeField] private GameObject TileSDP;
    [SerializeField] private GameObject TileCUP;
    [SerializeField] private GameObject TileCDP;

    public GameObject InstantinateTile(int xcoord, Tile tile)
    {
        GameObject currentprefab;
        switch (tile)
        {
            case Tile.Default:
                currentprefab = TileDefaultP;
                break;
            case Tile.DownSpike:
                currentprefab = TileSDP;
                break;
            case Tile.UpSpike:
                currentprefab = TileSUP;
                break;
            case Tile.DownCoin:
                currentprefab = TileCDP;
                break;
            case Tile.UpCoin:
                currentprefab = TileCUP;
                break;
            default:
                currentprefab = TileDefaultP;
                break;
        }
        return Instantiate(currentprefab, new Vector3(xcoord + LevelGenerator.xOrigin, 0, 0), Quaternion.identity);
    }
}
