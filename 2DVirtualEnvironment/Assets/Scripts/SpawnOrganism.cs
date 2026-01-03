using UnityEngine;

public class SpawnOrganism : MonoBehaviour
{
    public GameObject greenOrganismPrefab;
    public GameObject purpOrganismPrefab;
    public GameObject yellowOrganismPrefab;

    // holds organisms for organization in hierarchy
    private GameObject greenParent;
    private GameObject purpParent;
    private GameObject yellowParent;

    // bounds for spawning
    private float maxX = 40.0f;
    private float maxY = 40.0f;

    // start counts
    [Header("Starting Organism Counts")]
    public int startingGreenOrgs = 10;
    public int startingPurpOrgs = 10;
    public int startingYellowOrgs = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        greenParent = GameObject.FindWithTag("greenparent");
        purpParent = GameObject.FindWithTag("purpparent");
        yellowParent = GameObject.FindWithTag("yellowparent");

        for (int i = 0; i < startingGreenOrgs; i++)
        {
            spawnOrg(greenOrganismPrefab, greenParent);
        }
        for (int i = 0; i < startingPurpOrgs; i++)
        {
            spawnOrg(purpOrganismPrefab, purpParent);
        }
        for (int i = 0; i < startingYellowOrgs; i++)
        {
            spawnOrg(yellowOrganismPrefab, yellowParent);
        }
    }

    private void spawnOrg(GameObject orgPrefab, GameObject parentObj)
    {
        // random position within bounds
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), orgPrefab.transform.position.z);

        //random rotation
        GameObject newOrg = Instantiate(orgPrefab, spawnPos, Quaternion.identity);
        newOrg.transform.parent = parentObj.transform;
        newOrg.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // random scale
        float randScale = Random.Range(0.5f, 1.5f);
        newOrg.transform.localScale = new Vector3(randScale, randScale, 1);

        
    }
}
