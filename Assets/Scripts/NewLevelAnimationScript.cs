using UnityEngine;
using UnityEngine.UI;

public class NewLevelAnimationScript : MonoBehaviour
{
    private Canvas canv;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject text, image;

    private int anim_time = 2;

    void Start()
    {
        canv = GetComponent<Canvas>();
    }

    public void NewLevelAnim()
    {
        canv.enabled = true;
        Invoke(nameof(AutoDisableCanvas), anim_time);

        if (image.GetComponent<Animation>().isPlaying)
        {
            image.GetComponent<Animation>().Stop();
        }
        image.GetComponent<Animation>().Play();

        if (text.GetComponent<Animation>().isPlaying)
        {
            text.GetComponent<Animation>().Stop();
        }
        text.GetComponent<Animation>().Play();

        text.GetComponent<Text>().text = "Level: " + (main.GetComponent<GameMaster>().GetCurrentScore() + 2).ToString();
    }

    private void AutoDisableCanvas()
    {
        canv.enabled = false;
    }
}
