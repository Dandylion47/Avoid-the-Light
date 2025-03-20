using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //movement 
    public float moveSpeed = 6;
    private Rigidbody rb;

    //Vector3 to store the players location at all times. This was we can accelerate
    //Velocity
    private Vector3 movement;

    //Jump Force
    public float jumpHeight = 20f;
    public bool isGrounded;
    public float groundCheckLength = 0.6f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the rigidbody thus giving it a variable value
        rb = GetComponent<Rigidbody>();

        //Freeze all fotations on the ridgid body
        rb.freezeRotation = true;

        //Make cursor invisible while playing game. ESC key to release.
        //Why UnityEngine?? I dont get it
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /*//Check the ground with function
        isGrounded = checkGround();

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Sprint();
            }
        }*/
    }
    bool checkGround()
    {
        RaycastHit hit;

        //Draw a ray downward. Out hit means "Where do I store the result?"
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckLength, groundLayer))
        {
            return true;
        }
        return false;
    }

    //Update at fixed interval rather than each frame
    private void FixedUpdate()
    {
        //Create two temp float variables called h and v
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Call move player and send the two floats to the function
        movePlayer(h, v);
    }

    void movePlayer(float hSpeed, float vSpeed)
    {
        //Set the movement vector to vSpeed * transford.forward + hSpeed * transform.right
        movement = (transform.forward * vSpeed) + (transform.right * hSpeed);

        //Normalized stops player from accelerating when holding two buttons
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    /*void Sprint()
    {
        //Input for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Add a force upward * jumpHeight
            //ForceMode.Impulse means "right away"
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }*/
}
