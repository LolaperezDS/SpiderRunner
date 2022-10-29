using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Text gold_text;
    [SerializeField] private GameObject main;
    private void Start()
    {
        gold_text = GetComponent<Text>();
    }


    private void Update()
    {
        gold_text.text = main.GetComponent<GameMaster>().GetGold().ToString();
    }
}
