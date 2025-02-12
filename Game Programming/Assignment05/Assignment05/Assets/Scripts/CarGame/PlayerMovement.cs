﻿using System.Collections;
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
            transform.up = movement;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

            rigidBody2d.velocity = transform.up * speed;
          
        }
        else
        {
            rigidBody2d.velocity = Vector3.zero;
        }
        
    }
}
