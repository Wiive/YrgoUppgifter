using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Spawn Manager");
                go.AddComponent<SpawnManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void StartSpawning()
    {
        Debug.Log("Start spawning. ");
    }

    void Start()
    {
        Debug.Log(Player.Instance.name);
    }
}
