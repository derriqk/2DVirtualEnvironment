using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject camera;
    public GameObject camBlock;
    public int speed = 1;
    public float mouseSpeed = 1;
    public int maxDistance = 5; // distance from origin 0,0

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindWithTag("maincam");
        camBlock = GameObject.FindWithTag("camblock");
    }

    // Update is called once per frame
    void Update()
    {
        // get movement input every frame
        getMovementInput(); // WASD for main movement

        rightleftMouse(); // mouse left/right for horizontal movement
    }

    private void getMovementInput()
    {
        if (Input.GetMouseButton(0))
        {
            return; // disable WASD movement when mouse button is held
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (camera.transform.position.y >= maxDistance) 
            {
                return; 
            }
            camera.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (camera.transform.position.y <= -maxDistance) 
            {
                return; 
            }
            camera.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (camera.transform.position.x <= -maxDistance) 
            {
                return; 
            }
            camera.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (camera.transform.position.x >= maxDistance) 
            {
                return; 
            }
            camera.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
    }

    private void rightleftMouse() 
    {
        // moving mouse left or right makes the object move left or right, dragging needed
        if (!Input.GetMouseButton(0)) 
        {
            return;
        }
        float mouseX = Input.GetAxis("Mouse X");
        
        // only allow movement if the camBlock is outside a certain range from the camera
        if (camBlock.transform.position.x > camera.transform.position.x - 2.5f && camBlock.transform.position.x < camera.transform.position.x + 2.5f) 
        {
            if (camBlock.transform.position.x + mouseX*mouseSpeed < camera.transform.position.x - 2.5f || camBlock.transform.position.x + mouseX*mouseSpeed > camera.transform.position.x + 2.5f) 
            {
                return; // prevent moving outside the allowed range
            }
            camBlock.transform.position += new Vector3(mouseX*mouseSpeed, 0, 0) * Time.deltaTime * speed;
        } else
        {
            // if the camBlock is outside the range, move it back towards the camera
            if (camBlock.transform.position.x <= camera.transform.position.x - 2.5f) 
            {
                camBlock.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }
            if (camBlock.transform.position.x >= camera.transform.position.x + 2.5f) 
            {
                camBlock.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }

        // if camera immediately shoots too far
        if (camBlock.transform.position.x < camera.transform.position.x - 5f) 
        {
            camBlock.transform.position = new Vector3(camera.transform.position.x - 5f, camBlock.transform.position.y, camBlock.transform.position.z);
        } else if (camBlock.transform.position.x > camera.transform.position.x + 5f) 
        {
            camBlock.transform.position = new Vector3(camera.transform.position.x + 5f, camBlock.transform.position.y, camBlock.transform.position.z);
        }
    }

}
