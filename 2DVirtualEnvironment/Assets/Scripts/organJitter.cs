using UnityEngine;
using System.Collections.Generic;

public class organJitter : MonoBehaviour
{
    public List<GameObject> organs; // dynamic, set this in the inspector
    public GameObject outerbody;
    private float boundX;
    private float boundY;
    private float randRotate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set bounds for jittering
        boundX = outerbody.transform.localScale.x * 0.05f;
        boundY = outerbody.transform.localScale.y * 0.05f;

        randRotate = Random.Range(2f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject organ in organs)
        {
            jitter(organ);
            rotate(organ);
        }
    }

    private void jitter(GameObject obj) // for slight random movement for inner body
    {
        float jitterX = Random.Range(-0.002f, 0.002f);
        float jitterY = Random.Range(-0.002f, 0.002f);

        // check bounds
        Vector3 currentPos = obj.transform.localPosition;
        if (currentPos.x + jitterX > boundX || currentPos.x + jitterX < -boundX)
        {
            jitterX = -jitterX;
        }
        if (currentPos.y + jitterY > boundY || currentPos.y + jitterY < -boundY)
        {
            jitterY = -jitterY;
        }

        obj.transform.localPosition += new Vector3(jitterX, jitterY, 0);
    }

    private void rotate(GameObject obj)
    {
        obj.transform.Rotate(0, 0, randRotate * Time.deltaTime);
    }

}
