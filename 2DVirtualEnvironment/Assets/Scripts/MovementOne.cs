using UnityEngine;
using System.Collections;

// for a directional movement style

public class MovementOne : MonoBehaviour
{
    public GameObject selfObject;
    public GameObject nose; // front of organism to indicate direction
    private float moveSpeed = 0.5f;
    private float interval;
    private float timer = 0f;
    private float maxDistance = 40.0f;

    private float parentRotateInterval = 0.1f;
    private float parentRotateTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interval = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            pickRandomRotation();
            timer = 0f;
            interval = Random.Range(1f, 3f);
        }
        moveForward(); // per frame, or set to use a timer again
        
        if (parentRotateTimer >= parentRotateInterval)
        {
            selfObject.transform.Rotate(0, 0, Random.Range(-1f, 1f));
            parentRotateTimer = 0f;
        }
    }

    private void pickRandomRotation()
    {
        // if nose is too far from center just turn 90
        if (nose.transform.position.magnitude > maxDistance)
        {
            float flipRotation = 90f; 
            StartCoroutine(RotateOverTime(flipRotation, 1f));

            for (int i = 0; i < 20; i++)
            {
                moveForward();
            }
            return;
        }

        // random rotate
        float randomRotate = Random.Range(-45f, 45f);
        StartCoroutine(RotateOverTime(randomRotate, 1f));
    }

    private IEnumerator RotateOverTime(float angle, float duration)
    {
        Quaternion initialRotation = selfObject.transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, angle);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            selfObject.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        selfObject.transform.rotation = targetRotation;
    }
    private void moveForward()
    {
        Vector3 direction = (nose.transform.position - selfObject.transform.position).normalized;
        selfObject.transform.position += direction * moveSpeed * Time.deltaTime;
    }

}