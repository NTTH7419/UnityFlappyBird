using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 3;
    public float destroyXPosition = -10;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.isAlive)
        {
            return;
        }

        transform.position += moveSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
