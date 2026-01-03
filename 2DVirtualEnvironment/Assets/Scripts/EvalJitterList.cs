using UnityEngine;
using System.Collections.Generic;

public class EvalJitterList : MonoBehaviour
{
    public GameObject[] evalObjects;
    private float randDelayTime;
    private float randSpeed;
    private float boundX = 0.1f;
    private float boundY = 0.1f;

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

        float jitterX = Random.Range(-0.02f, 0.02f);
        float jitterY = Random.Range(-0.02f, 0.02f);

        if (evalObject.transform.localPosition.x + jitterX > boundX || evalObject.transform.localPosition.x + jitterX < -boundX)
        {
            jitterX = -jitterX;
        }
        if (evalObject.transform.localPosition.y + jitterY > boundY || evalObject.transform.localPosition.y + jitterY < -boundY)
        {
            jitterY = -jitterY;
        }

        evalObject.transform.localPosition += new Vector3(jitterX * 0.4f, jitterY * 0.4f, 0);
    }
}
