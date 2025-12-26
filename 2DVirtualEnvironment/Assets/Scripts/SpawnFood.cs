using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public int maxFoodItems = 20;
    public int currentFoodItems = 0;

    // bounds for spawning food
    public float maxX = 8.0f;
    public float maxY = 8.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewFood()
    {
        if (currentFoodItems < maxFoodItems)
        {
            float randomX = Random.Range(-maxX, maxX);
            float randomY = Random.Range(-maxY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);
            Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
            currentFoodItems++;
        }
    }
}
