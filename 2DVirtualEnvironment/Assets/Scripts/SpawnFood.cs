using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject foodParent;
    public int maxFoodItems = 20;
    public int currentFoodItems = 0;
    public float spawnInterval = 1.0f;

    // bounds for spawning food
    private float maxX = 40.0f;
    private float maxY = 40.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foodParent = GameObject.FindWithTag("foodparent");
        for (int i = 0; i < maxFoodItems; i++)
        {
            SpawnNewFood();
        }
    }

    public void SpawnNewFood()
    {
        if (currentFoodItems < maxFoodItems)
        {
            float randomX = Random.Range(-maxX, maxX);
            float randomY = Random.Range(-maxY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);
            GameObject food = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
            food.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            food.transform.parent = foodParent.transform;
            currentFoodItems++;
        }
    }
}
