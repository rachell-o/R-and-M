using UnityEngine;

//We need this in order to press buttons based on the player input we set up outside of the script
using UnityEngine.InputSystem;

//This is the system used to control the player
public class PlayerController : MonoBehaviour
{
    //From my knowledge, a Vector2 variable is typically coordinate that can represent multiple things
    //for example, in this script it is used as way to get an input direction for movement
    Vector2 moveInput;

    //A variable that can interact with rigidbodies and is used to help move the character
    Rigidbody2D rb;

    [Header("Player Stats")]
    //Allows for the changing of speed both in and out of this script
    public float speed;
    //Jump stat has not been implemented yet ***** need to do that with main pc.
    public float jump;


    void Awake()
    {
        //Gets the Rigidbody of the player character for use in adding force or velocity to the character
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveInput);

        //This actually moves the character and is currently flawed due 
        // to the fact it can also apply force in an upward/downward direction
        rb.AddForce(moveInput * speed);
    }

    //OnJump gets called whenever an Input from the UnityEngine.InputSystem recognizes an input from the player/user (Spacebar)
    void OnJump(InputValue value)
    {
        //if space is pressed
        if (value.isPressed)
        {
            //Debug.Log("Jumped");

            //It will keep the character's velocity and apply force upwards
            //currently flawed since it doesn't check for ground
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);
        }
    }

    //OnMove gets called whenever an Input from the UnityEngine.InputSystem recognizes an input from the player/user (WASD)
    void OnMove(InputValue value)
    {
        //moveInput gets a "coordinate" i.e. (x,y) from WASD when any of those are pressed
        // W = (0,1), D = (1, 0), S = (0, -1), A = (-1, 0)
        moveInput = value.Get<Vector2>();
    }
}
