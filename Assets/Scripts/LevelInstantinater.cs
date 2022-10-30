using UnityEngine;

public class LevelInstantinater : MonoBehaviour
{
    private GameMaster main;
    private TileFactory tf;
    [SerializeField] private GameObject lvlEndPrefab;

    public GameObject levelEndTrigger;
    public GameObject[] level_stack;


    private void Start()
    {
        main = GetComponent<GameMaster>();
        tf = GetComponent<TileFactory>();
    }
    public void InstantinateLevel()
    {
        Tile[] level_raw = LevelGenerator.GeneratrLevel(main.GetLengthOfLevel());
        level_stack = new GameObject[level_raw.Length];

        for (int i = 0; i < level_raw.Length; i++)
        {
            level_stack[i] = tf.InstantinateTile(i, level_raw[i]);
        }

        levelEndTrigger = Instantiate(lvlEndPrefab, new Vector3(level_raw.Length - LevelGenerator.endOffset + LevelGenerator.xOrigin + 2, 0, 0), Quaternion.identity);
    }

    public void DestroyCurrentLevel()
    {
        foreach (GameObject i in level_stack)
        {
            Destroy(i.gameObject);
        }
        Destroy(levelEndTrigger.gameObject);
        InstantinateLevel();
    }
}
