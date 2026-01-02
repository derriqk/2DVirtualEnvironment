using UnityEngine;

public class EvalJitterList : MonoBehaviour
{
    public GameObject[] evalObjects;
    private float randDelayTime;
    private float randSpeed;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject evalObject in evalObjects)
        {
            jitterEVal(evalObject);
        }
    }

    private void jitterEVal(GameObject evalObject)
    {
        randDelayTime = Random.Range(0.5f, 2f);
        randSpeed = Random.Range(1f, 3f);

        float jitterX = Mathf.PerlinNoise(Time.time * randSpeed, 0f + randDelayTime) - 0.5f;
        float jitterY = Mathf.PerlinNoise(0f + randDelayTime, Time.time * randSpeed) - 0.5f;

        evalObject.transform.localPosition += new Vector3(jitterX * 0.01f, jitterY * 0.01f, 0);
    }
}
