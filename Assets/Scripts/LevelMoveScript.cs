using UnityEngine;

public class LevelMoveScript : MonoBehaviour
{
    private LevelInstantinater LI;
    private GameMaster GM;
    public Vector3 forward = Vector3.left;
    void Start()
    {
        LI = GetComponent<LevelInstantinater>();
        GM = GetComponent<GameMaster>();
    }

    void Update()
    {
        if (GM.isPlying)
        {
            foreach (GameObject i in LI.level_stack)
            {
                i.transform.Translate(forward * GM.GetSpeed() * Time.deltaTime);
            }
            LI.levelEndTrigger.transform.Translate(forward * GM.GetSpeed() * Time.deltaTime);
        }
    }
}
