using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private IBlink blink_effect;

    [SerializeField] private ParticleSystem deathPS;
    [SerializeField] private ParticleSystem blinkPS;

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
        blink_effect = GetComponentInChildren<IBlink>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) Blink();
    }

    private void Blink()
    {
        if (main.GetComponent<GameMaster>().isRunning)
        {
            renderer.flipY = isBottom;
            isBottom = !isBottom;
            if (isBottom) transform.position = botPosition;
            else transform.position = topPosition;
            BlinkEffect();
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
        Invoke(nameof(LevelDesroy), 1);
        Invoke(nameof(LevelCreate), 1);
        anim_new_lvl.GetComponent<NewLevelAnimationScript>().NewLevelAnim();
    }

    private void LevelDesroy() => main.GetComponent<LevelInstantinater>().DestroyCurrentLevel();
    private void LevelCreate() => main.GetComponent<LevelInstantinater>().InstantinateLevel();

    private void EndOfGame()
    {
        anim_endgame.GetComponent<GameOverAnimation>().GameOverAnim();
        main.GetComponent<GameMaster>().isRunning = false;
        Invoke(nameof(LevelDesroy), 1);
        Debug.Log("you are dead");
    }


    private void BlinkEffect()
    {
        if (blink_effect != null)
        {
            if (isBottom) blink_effect.BlinkUp();
            else blink_effect.BlinkDown();
        }
        else Debug.LogError("Effect of blink is NONE");
    }

    public float GetSpeed() => main.GetComponent<GameMaster>().GetSpeed();
}
