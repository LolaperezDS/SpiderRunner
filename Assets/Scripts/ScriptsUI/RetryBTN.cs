using UnityEngine;
using UnityEngine.UI;

public class RetryBTN : MonoBehaviour
{
    [SerializeField] private GameObject GameOverAnim;
    [SerializeField] private GameObject Main;
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Retry);
        btn.enabled = false;
    }


    public void RetryDelay()
    {
        Invoke(nameof(ActivateButton), 1.05f);
    }

    private void ActivateButton()
    {
        btn.enabled = true;
    }

    private void Retry()
    {
        btn.enabled = false;
        GameOverAnim.GetComponent<GameOverAnimation>().canv.enabled = false;
        Main.GetComponent<LevelInstantinater>().InstantinateLevel();
        Main.GetComponent<GameMaster>().isPlying = true;
        Main.GetComponent<GameMaster>().currentScore = 0;
    }
}
