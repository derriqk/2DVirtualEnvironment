using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindWithTag("maincam");
    }

    // Update is called once per frame
    void Update()
    {
        // get movement input every frame
        getMovementInput();
    }

    private void getMovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            camera.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 5;
        }
        if (Input.GetKey(KeyCode.S))
        {
            camera.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * 5;
        }
        if (Input.GetKey(KeyCode.A))
        {
            camera.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * 5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            camera.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 5;
        }
    }
}
