using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDController : MonoBehaviour
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
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        var move = new Vector3(x, y, 0);

        playerMovement.MovePlayer(move);
    }
}
