using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private ParticleSystem deathPS;

    [SerializeField] private GameObject main;
    [SerializeField] private GameObject anim_new_lvl;
    [SerializeField] private GameObject anim_endgame;

    [SerializeField] private SpriteRenderer renderer;

    private bool isBottom = true;
    private Vector3 botPosition = new Vector3(0, -0.6f, 0);
    private Vector3 topPosition = new Vector3(0, 0.6f, 0);
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = botPosition;
        renderer = GetComponentInChildren<SpriteRenderer>();
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
            renderer.flipY = false;
            transform.position = botPosition;
        }
        else
        {
            renderer.flipY = true;
            transform.position = topPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            deathPS.Play();
            main.GetComponent<GameMaster>().SetHighScore(main.GetComponent<GameMaster>().GetCurrentScore());
            EndOfGame();
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
        Invoke(nameof(LevelDesroy), 1);
        Invoke(nameof(LevelCreate), 1);
        anim_new_lvl.GetComponent<NewLevelAnimationScript>().NewLevelAnim();
    }

    private void LevelDesroy()
    {
        main.GetComponent<LevelInstantinater>().DestroyCurrentLevel();
    }

    private void LevelCreate()
    {
        main.GetComponent<LevelInstantinater>().InstantinateLevel();
    }

    private void EndOfGame()
    {
        anim_endgame.GetComponent<GameOverAnimation>().GameOverAnim();
        main.GetComponent<GameMaster>().isPlying = false;
        Invoke(nameof(LevelDesroy), 1);
        Debug.Log("you are dead");
    }
}
