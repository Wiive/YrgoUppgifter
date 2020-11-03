using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
 
    }
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }
}
