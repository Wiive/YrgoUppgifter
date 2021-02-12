using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            move = mouse - Camera.main.WorldToScreenPoint(transform.position);
        }

        playerMovement.MovePlayer(move);
    }
}
