using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerShadow : MonoBehaviour
{
    //Own (not better) movement that uses tranform up and right.
    
    public float speed;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position += transform.up * -speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -speed * Time.deltaTime;
        }
    }
}
