using UnityEngine;

public class EvalJitter : MonoBehaviour
{
    public GameObject evalObject;
    private float randDelayTime;
    private float randSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randDelayTime = Random.Range(0.5f, 2f);
        randSpeed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        jitterEvalObject();
    }

    private void jitterEvalObject()
    {
        float jitterX = Mathf.PerlinNoise(Time.time * randSpeed, 0f + randDelayTime) - 0.5f;
        float jitterY = Mathf.PerlinNoise(0f + randDelayTime, Time.time * randSpeed) - 0.5f;

        evalObject.transform.localPosition += new Vector3(jitterX * 0.001f, jitterY * 0.001f, 0);
    }
}
