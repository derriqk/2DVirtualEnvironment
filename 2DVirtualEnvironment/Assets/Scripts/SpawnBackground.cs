using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBackground : MonoBehaviour
{
    private GameObject objParent;
    private GameObject spawnblock; // where to spawn the background blocks
    private Bounds spawnBounds;
    public List<GameObject> speckPrefabs;
    public int maxX = 100; // once speck reaches 80, respawn and recycle
    public int spawncount;
    public float minsize;
    public float maxsize;
   public float baseSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objParent = GameObject.FindWithTag("mapextra");
        spawnblock = GameObject.FindWithTag("spawnblock");
        spawnBounds = spawnblock.GetComponent<BoxCollider2D>().bounds;

        for (int i = 0; i < spawncount; i++)
        {
            foreach (GameObject speckPrefab in speckPrefabs) 
            {
                float headstart = Random.Range(maxX*.1f, maxX*2f); // so they don't all spawn at the same time
                spawnSpeck(speckPrefab, headstart);
            }
        }
    }

    private float decideSpeckSpeed(GameObject speck)
    { 
        // decides speed based on size
        float sizeFactor = speck.transform.localScale.x; 
        return baseSpeed / sizeFactor; 
        
    }
    private IEnumerator drift(GameObject speck, float speed)
    {
        while (speck.transform.position.x < maxX)
        {
            Vector3 pos = speck.transform.localPosition;
            pos.x += speed * Time.deltaTime;
            pos.y += Random.Range(-0.03f, 0.03f); // slight random drift up and down
            speck.transform.localPosition = pos;
            yield return null;
        }

        speck.transform.localPosition = new Vector3(spawnBounds.min.x, Random.Range(spawnBounds.min.y, spawnBounds.max.y), 0);
        speck.transform.localScale = Vector3.one; // reset scale
        speck.transform.Rotate(0, 0, Random.Range(0f, 360f)); // random rotation
        speck.transform.localScale *= Random.Range(minsize, maxsize);
        speed = decideSpeckSpeed(speck);
        StartCoroutine(drift(speck, speed));
    }

    private void spawnSpeck(GameObject speckPrefab, float headstart = 0f) // aways 0 unless called otherwise
    {
        float spawnY = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        Vector3 spawnPos = new Vector3(spawnBounds.min.x + headstart, spawnY, speckPrefab.transform.position.z);
        GameObject speck = Instantiate(speckPrefab, spawnPos, Quaternion.identity);
        speck.transform.localScale *= Random.Range(minsize, maxsize); // random size
        speck.transform.Rotate(0, 0, Random.Range(0f, 360f)); // random rotation
        speck.transform.parent = objParent.transform;
        float speed = decideSpeckSpeed(speck);
        StartCoroutine(drift(speck, speed));
    }
}
