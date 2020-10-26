using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPinky : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(x, y);

        rb2d.AddForce(movement * speed);
    }
}
