using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTagManager : MonoBehaviour
{
    public GameObject NameTagPrefab;

    public GameObject[] players;

    public Vector3 offset;
    internal GameObject[] nameTags;

    void Awake()
    {
        nameTags = new GameObject[players.Length];

        var parent = GameObject.Find("Canvas").transform;
        
        for (int i = 0; i < nameTags.Length; i++)
        {
            nameTags[i] = Instantiate(NameTagPrefab, parent);
        }
    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            nameTags[i].transform.position = Camera.main.WorldToScreenPoint(players[i].transform.position + offset);
        }
    }
}
