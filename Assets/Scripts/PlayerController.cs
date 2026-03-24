using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveInput);
        rb.AddForce(moveInput * speed);
    }

    void OnJump(InputValue value) {
        if (value.isPressed) {
            Debug.Log("Jumped");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);
        }
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }
}
