using UnityEngine;

public class LevelMoveScript : MonoBehaviour
{
    private LevelInstantinater levelInstantinater;
    private GameMaster gameMaster;
    public Vector3 forward = Vector3.left;
    void Start()
    {
        levelInstantinater = GetComponent<LevelInstantinater>();
        gameMaster = GetComponent<GameMaster>();
    }

    void Update()
    {
        if (!gameMaster.isRunning) return;
        foreach (GameObject i in levelInstantinater.level_stack) i.transform.Translate(forward * gameMaster.GetSpeed() * Time.deltaTime);
        levelInstantinater.levelEndTrigger.transform.Translate(forward * gameMaster.GetSpeed() * Time.deltaTime);
    }
}
