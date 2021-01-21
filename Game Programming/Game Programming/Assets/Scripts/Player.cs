using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingelton<Player>
{
    public string name;
    void Start()
    {
        SpawnManager.Instance.StartSpawning();
    }

    public override void Init()
    {
        base.Init();

        Debug.Log("Player is adding to monosingelton Init");
    }
}
