using UnityEngine;

public class SpawnOrganism : MonoBehaviour
{
    public GameObject greenOrganismPrefab;
    public GameObject purpOrganismPrefab;

    // holds organisms for organization in hierarchy
    private GameObject greenParent;
    private GameObject purpParent;

    // bounds for spawning
    private float maxX = 40.0f;
    private float maxY = 40.0f;

    // start counts
    [Header("Starting Organism Counts")]
    public int startingGreenOrgs = 10;
    public int startingPurpOrgs = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        greenParent = GameObject.FindWithTag("greenparent");
        purpParent = GameObject.FindWithTag("purpparent");

        for (int i = 0; i < startingGreenOrgs; i++)
        {
            spawnOrg(greenOrganismPrefab, greenParent);
        }
        for (int i = 0; i < startingPurpOrgs; i++)
        {
            spawnOrg(purpOrganismPrefab, purpParent);
        }
    }

    private void spawnOrg(GameObject orgPrefab, GameObject parentObj)
    {
        // random position within bounds
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0);

        //random rotation
        GameObject newOrg = Instantiate(orgPrefab, spawnPos, Quaternion.identity);
        newOrg.transform.parent = parentObj.transform;
        newOrg.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }
}
