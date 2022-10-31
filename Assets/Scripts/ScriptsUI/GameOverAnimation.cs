using UnityEngine;
using UnityEngine.UI;

public class GameOverAnimation : MonoBehaviour
{
    public Canvas canv;

    [SerializeField] private GameObject main;

    [SerializeField] private GameObject image;
    [SerializeField] private GameObject TextStatic;
    [SerializeField] private GameObject TextHS;
    [SerializeField] private GameObject TextCS;
    [SerializeField] private GameObject imageBTN;
    [SerializeField] private GameObject TextBTN;
    void Start()
    {
        canv = GetComponent<Canvas>();
    }

    public void GameOverAnim()
    {
        canv.enabled = true;
        imageBTN.GetComponent<RetryBTN>().RetryDelay();

        TextHS.GetComponent<Text>().text = "High Score: " + main.GetComponent<GameMaster>().GetHighScore().ToString();
        TextCS.GetComponent<Text>().text = "Score: " + main.GetComponent<GameMaster>().GetCurrentScore().ToString();

        image.GetComponent<Animation>().Play();
        TextStatic.GetComponent<Animation>().Play();
        TextHS.GetComponent<Animation>().Play();
        TextCS.GetComponent<Animation>().Play();
        imageBTN.GetComponent<Animation>().Play();
        TextBTN.GetComponent<Animation>().Play();
    }
}
