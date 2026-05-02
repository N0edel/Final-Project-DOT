using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;

    private BoxCollider2D spawnArea;
    private float timer;

    void Awake()
    {
        spawnArea = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0;
        }
    }

    void SpawnObject()
    {
        // Get the bounds of the BoxCollider2D
        Bounds bounds = spawnArea.bounds;

        // Pick a random point within those bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector2 spawnPos = new Vector2(x, y);

        // Spawn the prefab
        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
