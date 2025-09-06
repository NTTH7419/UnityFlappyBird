using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D Rigitbody;
    public LogicScript logic;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    public AudioClip flapSound;
    public AudioClip collideSound;

    public float flapStrength = 5;
    public float maxYPos = 10;

    public Sprite[] birdSprites;
    private int spriteIndex;
    private float spriteChangeTimer = 0;
    public float spriteChangeRate = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigitbody.bodyType = RigidbodyType2D.Static;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.isAlive = true;
        spriteIndex = 2;
        spriteRenderer.sprite = birdSprites[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.isAlive)
        {
            return;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {   
            if (!logic.isRunning)
            {
                logic.isRunning = true;
                Rigitbody.bodyType = RigidbodyType2D.Dynamic;
                logic.pressSpaceText.gameObject.SetActive(false);
            }
            Rigitbody.linearVelocity = Vector2.up * flapStrength;
            spriteIndex = 0;
            spriteRenderer.sprite = birdSprites[spriteIndex];
            audioSource.PlayOneShot(flapSound);
        }

        if (transform.position.y > maxYPos || transform.position.y < -maxYPos)
        {
            GameOver();
        }

        if (spriteIndex < birdSprites.Length - 1)
        {
            if (spriteChangeTimer < spriteChangeRate)
            {
                spriteChangeTimer += Time.deltaTime;
            }
            else
            {
                spriteIndex++;
                spriteRenderer.sprite = birdSprites[spriteIndex];
                spriteChangeTimer = 0;
            }
        }
    }

    void GameOver()
    {
        logic.isAlive = false;
        logic.isRunning = false;
        Rigitbody.bodyType = RigidbodyType2D.Static;
        audioSource.PlayOneShot(collideSound);
        logic.GameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }
}
