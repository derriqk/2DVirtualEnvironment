using UnityEngine;

// amoeba style movement, any direction, rotate randomly for effect

public class MovementTwo : MonoBehaviour
{
    public GameObject selfObject;
    public GameObject circle; // rotate to change nose direction
    public GameObject nose; // direction
    private float moveSpeed = 0.5f;
    private float interval;
    private float timer = 0f;
    private float maxDistance = 40.0f;
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
    }

    private void pickRandomRotation()
    {
        // if nose is too far from center just turn 90
        if (nose.transform.position.magnitude > maxDistance)
        {
            float flipRotation = 90f; 
            circle.transform.Rotate(0, 0, flipRotation);

            for (int i = 0; i < 20; i++)
            {
                moveForward();
            }
            return;
        }

        // random rotate
        float randomRotate = Random.Range(-45f, 45f);
        circle.transform.Rotate(0, 0, randomRotate);
    }

    private void moveForward()
    {
        Vector3 direction = (nose.transform.position - selfObject.transform.position);
        direction.z = 0f; 
        direction.Normalize(); 
        selfObject.transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
