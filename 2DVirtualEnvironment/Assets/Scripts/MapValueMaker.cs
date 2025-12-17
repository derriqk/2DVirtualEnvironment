using UnityEngine;

public class MapValueMaker : MonoBehaviour
{   
    public float[,] values = new float[100,100]; // this will hold noise value to use tiles with
    public int seed; // to be decided by player
    public GameObject spawntile; // tile to spawn
    public Sprite grass;
    public Sprite water;
    public GameObject tilesParent; // holds all tiles so it doesnt clutter hierarchy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawntile = GameObject.FindWithTag("spawnfortiles");
        tilesParent = GameObject.FindWithTag("tilesparent");

        populateValues(seed);

        spawnTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void populateValues(int seed)
    {
        float scale = .35f;

        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                // assign the value accordingly
                float xCoord = (float)x / 100 * 10 + seed;
                float yCoord = (float)y / 100 * 10 + seed;
                float sample = Mathf.PerlinNoise(xCoord * scale, yCoord * scale);
                values[x,y] = sample;
            }
        }
    }

    private void spawnTiles()
    {
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                GameObject tile = Instantiate(spawntile, new Vector3(x, y, 0), Quaternion.identity);
                tile.transform.parent = tilesParent.transform;
                SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();

                // decide which sprite to use based on value
                if (values[x,y] < 0.5f)
                {
                    renderer.sprite = water;
                }
                else
                {
                    renderer.sprite = grass;
                }
            }
        }
    }
}
