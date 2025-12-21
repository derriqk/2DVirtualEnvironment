using UnityEngine;

public class MapValueMaker : MonoBehaviour
{   
    public float[,] values; // this will hold noise value to use tiles with
    public int gridSize; // dimensions of value must be a perfect square
    public int seed; // to be decided by player
    public float scale; // noise scale
    public GameObject spawntile; // tile to spawn
    // textures
    public Sprite grass;
    public Sprite water;
    public Sprite mountain;
    public Sprite sand;
    public GameObject tilesParent; // holds all tiles so it doesnt clutter hierarchy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        values = new float[gridSize, gridSize];

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

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
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
        int startpos = -(gridSize / 2);

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(spawntile, new Vector3(startpos + x, startpos + y, 0), Quaternion.identity);
                tile.transform.parent = tilesParent.transform;
                SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();

                // decide which sprite to use based on value
                if (values[x,y] < 0.5f) // ocean
                {
                    renderer.color = Color.blue;
                }
                else // land
                {
                    if (values[x,y] > 0.8f) // mountain
                    {
                        renderer.color = Color.gray;
                    }
                    else if (values[x,y] > 0.65f) // grass
                    {
                        renderer.color = Color.green;
                    }
                    else // sand
                    renderer.color = Color.yellow;
                }
            }
        }
    }
}
