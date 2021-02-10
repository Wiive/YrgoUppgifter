using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTagManager : MonoBehaviour
{
    public GameObject NameTagPrefab;
    public Vector3 offset;
    public GameObject[] players;
 
    internal GameObject[] nameTags;

    void Awake()
    {
        SpawnNameTags();
    }

    public void SpawnNameTags()
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
