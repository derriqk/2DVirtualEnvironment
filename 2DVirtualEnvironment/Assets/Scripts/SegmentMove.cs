using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// MovementOne + trailing segment rotation combined
public class SegmentMove : MonoBehaviour
{
    public List<Transform> evalLocations; // these are a list of objects that the eval will lerp between
    public GameObject evalObject; // the object that will move
    private float randSpeed;
    private float timer;
    private float randInterval;
    private int currentTargetIndex = 0;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // didnt do random since it looks boxy
        randSpeed = 1f; 
        randInterval = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= randInterval)
        {
            MoveEvalObject(currentTargetIndex);
            timer = 0f;
            currentTargetIndex = (currentTargetIndex + 1) % evalLocations.Count;
        } 
    }

    private void MoveEvalObject(int index)
    {
        Vector3 startPos = evalObject.transform.localPosition;
        Vector3 endPos = evalLocations[index].localPosition;
        StartCoroutine(MoveOverTime(startPos, endPos, randSpeed));
    }

    private IEnumerator MoveOverTime(Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            evalObject.transform.localPosition = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        evalObject.transform.localPosition = endPos;
    }
}