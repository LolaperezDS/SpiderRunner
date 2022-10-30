using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject main;

    private bool isBottom = true;
    private Vector3 botPosition = new Vector3(0, -0.6f, 0);
    private Vector3 topPosition = new Vector3(0, 0.6f, 0);
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = botPosition;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Blink();
        }
    }

    private void Blink()
    {
        isBottom = !isBottom;
        if (isBottom)
        {
            transform.position = botPosition;
        }
        else
        {
            transform.position = topPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            EndOfGame();
            main.GetComponent<GameMaster>().SetHighScore(main.GetComponent<GameMaster>().GetCurrentScore());
        }
        if (collision.gameObject.layer == 7)
        {
            LevelIsEndFuction();
            main.GetComponent<GameMaster>().IncrementCurrentScore();
        }
        if (collision.gameObject.layer == 6)
        {
            main.GetComponent<GameMaster>().IncrementGold();
            Destroy(collision.gameObject);
        }
    }

    private void LevelIsEndFuction()
    {
        Debug.Log("lvl is end");
        Invoke(nameof(LevelDesroy), 2);
    }

    private void LevelDesroy()
    {
        main.GetComponent<LevelInstantinater>().DestroyCurrentLevel();
    }

    private void EndOfGame()
    {
        Debug.Log("you are dead");
    }
}
