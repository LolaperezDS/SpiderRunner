using UnityEngine;
using UnityEngine.UI;

public class RetryBTN : MonoBehaviour
{
    [SerializeField] private GameObject GameOverAnim;
    [SerializeField] private GameObject Main;

    private bool DoubleClickProtection = true;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(RetryDelay);
    }


    private void RetryDelay()
    {
        if (DoubleClickProtection)
        {
            DoubleClickProtection = false;
            Invoke(nameof(Retry), 1);
        }
    }

    private void Retry()
    {
        GameOverAnim.GetComponent<GameOverAnimation>().canv.enabled = false;
        Main.GetComponent<LevelInstantinater>().InstantinateLevel();
        Main.GetComponent<GameMaster>().isPlying = true;
        Main.GetComponent<GameMaster>().currentScore = 0;
        DoubleClickProtection = true;
    }
}
