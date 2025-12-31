using UnityEngine;

public class foodanimation : MonoBehaviour
{
    public GameObject parent;
    public GameObject outerbody; 
    public GameObject innerbody;
    public GameObject organ1;
    public GameObject organ2;

    public float pulseSpeed; // speed it pulses

    private float upperScale; // the max it scales, to be randomized
    private float randomRotate; // the random rotation speed
    private float boundX;
    private float boundY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(.3f, 1.3f);
        // multiply the parent scale by a random size
        parent.transform.localScale = new Vector3(
            parent.transform.localScale.x * randomSize,
            parent.transform.localScale.y * randomSize,
            parent.transform.localScale.z * randomSize
            );

        upperScale = Random.Range(1.2f, 1.5f);
        randomRotate = Random.Range(2f, 10f);

        if (pulseSpeed == 0) // if not set in inspector
        {
            pulseSpeed = Random.Range(0.05f, .4f);
        }

        // randomly offset the innerbody location
        float offsetX = Random.Range(-0.025f, 0.025f);
        float offsetY = Random.Range(-0.025f, 0.025f);
        innerbody.transform.localPosition = new Vector3(offsetX, offsetY, innerbody.transform.localPosition.z);

        // randomly offset the organ1 location
        offsetX = Random.Range(-0.025f, 0.025f);
        offsetY = Random.Range(-0.025f, 0.025f);
        organ1.transform.localPosition = new Vector3(offsetX, offsetY, organ1.transform.localPosition.z);

        // set bounds for jittering
        boundX = outerbody.transform.localScale.x * 0.1f;
        boundY = outerbody.transform.localScale.y * 0.1f;
    }

    void Update()
    {
        pulse();
        jitter(innerbody);
        jitter(organ1);
        jitter(organ2);
        rotateParent();
    }

    private void pulse() // for the pulsing effect of the outer body, which affects the whole food item since it's the parent object
    {
        float scale = 1 + Mathf.PingPong(Time.time * pulseSpeed, upperScale - 1);
        outerbody.transform.localScale = new Vector3(scale, scale, scale);
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

    private void rotateParent() // for rotating the whole food item
    {
        parent.transform.Rotate(new Vector3(0, 0, randomRotate) * Time.deltaTime);
    }
}
