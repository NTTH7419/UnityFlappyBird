using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 1;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.isRunning)
        {
            return;
        }

        if (timer == 0)
        {
            spawnPipe();
        }
        else if (timer >= spawnRate)
        {
            timer = 0;
            spawnPipe();
        }
        timer += Time.deltaTime;
    }
    
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Vector3 spawn_position = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z);
        Instantiate(pipePrefab, spawn_position, transform.rotation);
    }
}
