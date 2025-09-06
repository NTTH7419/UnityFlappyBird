using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public AudioSource audioSource;
    
    public AudioClip scoreSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (logic.isRunning && collision.gameObject.layer == 3)
        {
            logic.addScore();
            audioSource.PlayOneShot(scoreSound);
        }
    }
}
