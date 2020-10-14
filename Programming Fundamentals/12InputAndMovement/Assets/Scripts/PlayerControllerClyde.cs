using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerClyde : MonoBehaviour
{
    //Uses velocity movement
    public float speed;
    Rigidbody2D rb2d;
    Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        movement = new Vector3(x, y);
        if (movement.sqrMagnitude > 1)
        {
            movement = movement.normalized;
        }   
    }

    private void FixedUpdate()
    {
        rb2d.velocity = movement * speed;
    }
}