using UnityEngine;
using UnityEngine.UI;

public class HighScoreOut : MonoBehaviour
{
    private Text hs_text;
    [SerializeField] private GameObject main;
    private void Start()
    {
        hs_text = GetComponent<Text>();
    }

    private void Update()
    {
        hs_text.text = main.GetComponent<GameMaster>().GetHighScore().ToString();
    }
}
