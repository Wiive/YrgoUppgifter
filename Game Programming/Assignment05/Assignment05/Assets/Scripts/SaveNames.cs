using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SaveNames : MonoBehaviour
{
    public TMP_InputField name1;
    public TMP_InputField name2;

    void Start()
    {
        name1.text = PlayerPrefs.GetString("p1-name", name1.text);
        name2.text = PlayerPrefs.GetString("p2-name", name2.text);
    }

    public void SavePlayerNames()
    {
        PlayerPrefs.SetString("p1-name", name1.text);
        PlayerPrefs.SetString("p2-name", name2.text);
    }
}
