using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    private Canvas canv;
    private int anim_time = 1;
    [SerializeField] private GameObject image;
    void Start()
    {
        canv = GetComponent<Canvas>();
        canv.enabled = true;
        Invoke(nameof(AutoDisableCanvas), anim_time);
        if (image.GetComponent<Animation>().isPlaying) image.GetComponent<Animation>().Stop();
        image.GetComponent<Animation>().Play();
    }
    private void AutoDisableCanvas() => canv.enabled = false;
}
