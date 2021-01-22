using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEditor.Experimental.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private void Start()
    {
        LoadData();
        LoadNames();
    }

    public void SaveData()
    {
        Debug.Log("Saved");

        Vector3 pos = Vector3.zero;

        pos.x = PlayerPrefs.GetFloat("p1");
    }


    public void LoadData()
    {
        Debug.Log("Loading");
    }

    public void LoadNames()
    {
        var nameTagManager = GetComponent<NameTagManager>();

        for (int i = 0; i < nameTagManager.nameTags.Length; i++)
        {
            nameTagManager.nameTags[i].GetComponent<TMP_Text>().text = PlayerPrefs.GetString("p" + (i+1) + "-name");
        }
    }

    public void SaveNames()
    {

    }
}
