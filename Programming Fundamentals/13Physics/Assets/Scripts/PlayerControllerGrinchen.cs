using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGrinchen : MonoBehaviour
{
    //Uses Translate movement
    public float speed;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, y, 0) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
