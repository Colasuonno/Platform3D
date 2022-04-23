using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 6f;
    public float vSpeed = 0;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float gravity = 9.81f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool grounded = controller.isGrounded;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // If the vector length >0.1
        if (direction.magnitude >= 0.1f)
        {

            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angleSmoot = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angleSmoot, 0f);

            direction *= speed;

        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(grounded);
        }
        
        if (grounded)
        {
            vSpeed = 0;
            if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
            {
                Debug.Log("Jump");
                vSpeed = 6f;
            }
        }
        // apply gravity acceleration to vertical speed:
        vSpeed -= gravity * Time.deltaTime;
        direction.y = vSpeed ; // include vertical speed in vel
        controller.Move(direction * Time.deltaTime);

        if (transform.position.y < 6)
        {
            Teleport(initialPosition);
            TileGenerator.clearPlatforms();
        }

    }


    void Teleport(Vector3 position)
    {
        transform.position = position;
    }

}
