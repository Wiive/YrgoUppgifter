using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 10;
    public string inputAxisHorizontal = "Horizontal";
    public string inputJump = "Jump";

    Rigidbody2D rb2d;
    Vector2 movement = new Vector2();

    bool grounded = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement
        float x = Input.GetAxis(inputAxisHorizontal);

        movement = new Vector3(x * speed, rb2d.velocity.y);

        if (Input.GetButtonDown(inputJump) && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
           // rb2d.velocity = new Vector2(rb2d.velocity.x,jumpPower);
        }           
    }

    private void FixedUpdate()
    {
        rb2d.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
}
