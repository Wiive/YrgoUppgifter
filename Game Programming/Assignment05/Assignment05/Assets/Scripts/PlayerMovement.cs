using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rigidBody2d;

    private void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector3 movement)
    {
        movement = movement.normalized;

        if (movement.sqrMagnitude > 0.05f)
        {
            rigidBody2d.velocity = transform.position + movement * speed;
        }
        else
            rigidBody2d.velocity = transform.position * 0f;
       
        //rigidBody2d.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }
}
